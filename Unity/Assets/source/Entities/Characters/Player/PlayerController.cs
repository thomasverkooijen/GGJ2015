using UnityEngine;
using System.Collections;

public class PlayerController : MovementController {

	protected PlayerView _view;

	protected override void Awake(){
		base.Awake();
		_controllerInputController.OnStickActive 	+= HandleOnStickActive;
		_controllerInputController.OnStickNotActive += HandleOnStickNotActive;
		_controllerInputController.OnButtonPressed	+= HandleOnButtonPressed;
		_model 	= gameObject.GetComponent<Player>() as Player;
		_view	= gameObject.GetComponent<PlayerView>();
	}



	protected override void Start (){
		base.Start ();
		AnimationManager.Play(_view.PlayerHead , "PlayerHeadWalk" , 0 , true);
		AnimationManager.Play(_view.PlayerLegs , "PlayerLegsWalk" , 0 , true);
	}

	protected override void Update(){
		base.Update();
		HandleHorizontalMovement();
		HandleVerticalMovement();
		HandleGravity();
		HandleObstructions();
		AnimationManager.SetFps(_view.PlayerLegs , "PlayerLegsWalk" , (int)(_xVelocity*450*Time.deltaTime));
	}

	void HandleOnButtonPressed (ControllerButton p_controllerButton, int p_playerIndex){
		if(_model.EntityID != p_playerIndex) return;
		switch(p_controllerButton){
		case ControllerButton.A:
			Jump();
			break;
		}
	}
	
	void HandleOnStickActive (StickType p_stickType, float p_speed, int p_playerIndex){
		if(_model.EntityID != p_playerIndex) return;
		switch(p_stickType){
		case StickType.LeftX:
			_xVelocity = MathHelper.IncrementTowards(_xVelocity , p_speed*_maxSpeed , _acceleration);
			break;
		}
	}
	void HandleOnStickNotActive (StickType p_stickType, float p_speed, int p_playerIndex){
		if(_model.EntityID != p_playerIndex) return;
		switch(p_stickType){
		case StickType.LeftX:
			_xVelocity = MathHelper.IncrementTowards(_xVelocity , 0 , _acceleration);
			break;
		}
	}
}
