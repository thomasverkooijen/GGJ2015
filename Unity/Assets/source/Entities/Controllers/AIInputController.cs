using UnityEngine;
using System.Collections;
using Assets.source.Entities.Controllers;
using Assets.source.Entities.Models;

public class AIInputController : MonoBehaviour, IController, IInputController
{
    private MovementController _player;
    private AIModel _AIModel;

    private float _AITimeStep = 0.25f;
    private float _decisionValue = 0.5f;

    void Start()
    {
        _AIModel = GetComponent<AIModel>();
        _decisionValue = Random.value;
        _player = GetComponent<MovementController>();
        StartCoroutine(AIStep());
    }

    IEnumerator AIStep()
    {
        _decisionValue = Random.value;
        yield return new WaitForSeconds(_AIModel.TimeStep);
        StartCoroutine(AIStep());
    }

    void Update()
    {
        if (_decisionValue >= 0.7f)
        {
            HandleOnStickActive(StickType.LeftX, Random.value, 5);
        }
        if (_decisionValue <= 0.3f)
        {
            HandleOnStickActive(StickType.LeftX, -Random.value, 5);
        }
        if (_decisionValue >= 0.45f && _decisionValue <= .55f)
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
