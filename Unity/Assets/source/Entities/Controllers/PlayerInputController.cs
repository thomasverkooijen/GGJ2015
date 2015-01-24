using UnityEngine;
using System.Collections;
using Assets.source.Entities.Controllers;

public class PlayerInputController : EventContainerBase, IInputController
{
    public int _playerIndex = 0;

    private MovementController _movementController;
    private CursorMovementController _cursorMovementController;
    private IMovementController _player;

    public bool IsOverseer = false;

    private bool _moveLeft = false;
    private bool _moveRight = false;

    ControllerInputEventController _controllerInputController;

    protected override void Awake()
    {
        _controllerInputController = new ControllerInputEventController(this);
        AddController(_controllerInputController);
        base.Awake();

        _controllerInputController.OnButtonPressed += HandleOnButtonPressed;
        _controllerInputController.OnButtonReleased += HandleOnButtonReleased;
        _controllerInputController.OnStickActive += HandleOnStickActive;

        _cursorMovementController = gameObject.GetComponent<CursorMovementController>();
        _movementController = gameObject.GetComponent<MovementController>();
        _player = _movementController;
        ToggleOverseerMode(IsOverseer);
    }

    public void HandleOnStickActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        if (p_playerIndex == _playerIndex)
        {
            switch (p_stickType)
            {
                case StickType.LeftX:
                    if (_player != null) _player.Move(p_speed);
                    break;
                case StickType.LeftY:
                    if (_player != null && IsOverseer) _player.Move(0.0f, p_speed);
                    break;
            }
        }
    }

    public void HandleOnButtonReleased(ControllerButton p_controllerButton, int p_playerIndex)
    {
        if (p_playerIndex == _playerIndex)
        {
            switch (p_controllerButton)
            {
                case ControllerButton.A:
                    if (_player != null) _player.Jump();
                    break;
            }
        }
    }

    public void HandleOnButtonPressed(ControllerButton p_controllerButton, int p_playerIndex)
    {
        if (p_playerIndex == _playerIndex)
        {
            //Handle button presses here
        }
    }

    public void ToggleOverseerMode(bool becomesOverseer)
    {
        if (becomesOverseer)
        {
            _movementController.enabled = false;
            _cursorMovementController.enabled = true;
            _player = GetComponent<CursorMovementController>();
            IsOverseer = true;
        }
        else
        {
            _movementController.enabled = true;
            _cursorMovementController.enabled = false;
            _player = GetComponent<MovementController>();
            IsOverseer = false;
        }
    }
}
