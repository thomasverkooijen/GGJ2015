using UnityEngine;
using System.Collections;

public class PlayerBehaviour : EventContainerBase {

	private Player	_player;

	private bool 	_moveLeft	= false;
	private bool	_moveRight	= false;

	ControllerInputEventController _controllerInputController;

	protected override void Awake (){
		_controllerInputController = new ControllerInputEventController(this);
		AddController(_controllerInputController);
		base.Awake();

		_controllerInputController.OnButtonPressed 	+= HandleOnButtonPressed;
		_controllerInputController.OnButtonReleased	+= HandleOnButtonReleased;
		_controllerInputController.OnStickActive	+= HandleOnStickActive;

		_player = gameObject.GetComponent<Player>();
	}

	void HandleOnStickActive (StickType p_stickType, float p_speed, int p_playerIndex){
		switch(p_stickType){
		case StickType.LeftX:
			if(_player != null) _player.Move(p_speed);
			break;
		}
	}

	void HandleOnButtonReleased (ControllerButton p_controllerButton, int p_playerIndex){
		switch(p_controllerButton){
		case ControllerButton.A:
			if(_player != null) _player.Jump();
			break;
		}
	}

	void HandleOnButtonPressed (ControllerButton p_controllerButton, int p_playerIndex){
	}

}
