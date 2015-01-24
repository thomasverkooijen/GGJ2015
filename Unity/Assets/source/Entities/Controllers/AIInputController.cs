using UnityEngine;
using System.Collections;
using Assets.source.Entities.Controllers;

public class AIInputController : MonoBehaviour, IController, IInputController
{
    private MovementController _player;

    void Start()
    {
        _player = GetComponent<MovementController>();
    }

    void Update()
    {
        float randomValue = Random.value;
        if (randomValue >= 0.7f)
        {
            HandleOnStickActive(StickType.LeftX, Random.value, 5);
        }
        if (randomValue <= 0.3f)
        {
            HandleOnStickActive(StickType.LeftX, -Random.value, 5);
        }
        if (randomValue >= 0.45f && randomValue <= .55f)
        {
            HandleOnButtonReleased(ControllerButton.A, 5);
        }
    }

    public void HandleOnStickActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        switch (p_stickType)
        {
            case StickType.LeftX:
                if (_player != null) _player.Move(p_speed);
                break;
        }
    }

    public void HandleOnButtonReleased(ControllerButton p_controllerButton, int p_playerIndex)
    {
        switch (p_controllerButton)
        {
            case ControllerButton.A:
                if (_player != null) _player.Jump();
                break;
        }
    }

    public void HandleOnButtonPressed(ControllerButton p_controllerButton, int p_playerIndex)
    {
    }
}
