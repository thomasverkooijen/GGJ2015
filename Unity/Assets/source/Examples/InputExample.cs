using UnityEngine;
using System.Collections;

public class InputExample : EventContainerBase {
	
	ControllerInputEventController _controllerInputController;

	protected override void Awake (){
		_controllerInputController = new ControllerInputEventController(this);
		AddController(_controllerInputController);
		base.Awake();

		_controllerInputController.OnStickActive += HandleOnStickActive;
		_controllerInputController.OnButtonPressed += HandleOnButtonPressed;
	}

	void HandleOnButtonPressed (ControllerButton b, int playerIndex){
		//Debug.Log("Button pressed: " + b + " player: " + playerIndex);
		switch(b){
		case ControllerButton.A :
			if(playerIndex == 1){
				AudioManager.Play(Camera.main.gameObject , true , "AudioTest1"); 
			}
			else{
				AudioManager.Play(null , false , "AudioTest1"); 
			}
			break;
		case ControllerButton.B:
			break;
		case ControllerButton.X:
			break;
		case ControllerButton.Y:
			break;
		}
	}

	void HandleOnStickActive (StickType stickType, float speed, int playerIndex){
		//Debug.Log("ActiveStick: " + stickType + " speed: " + speed + " player: " + playerIndex);
	}
}
