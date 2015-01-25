using UnityEngine;
using System.Collections;

public class PlayerController : MovementController {

	protected PlayerView _view;

	private AnimationComponent _animationComponentLegs;
	private AnimationComponent _animationComponentHead;

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
		//AnimationManager.Play(_view.PlayerHead , "PlayerJumpOne" , 0 , true);
		_animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerJump" , 0 , true);
	}

	protected override void Update(){
		base.Update();
		HandleHorizontalMovement();
		HandleVerticalMovement();
		HandleGravity();
		HandleObstructions();
		HandleAnimations();
		//AnimationManager.SetFps(_view.PlayerLegs , "PlayerLegsWalk" , (int)(_xVelocity*450*Time.deltaTime));
	}

	void HandleAnimations(){

		bool _onGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f);

		if(!_onGround){
			if(_yVelocity > 0){
				if(_animationComponentLegs == null) _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerInAirUp" , 20 , true);
				else if(_animationComponentLegs.Name != "PlayerInAirUp"){
					if(_animationComponentLegs.Name == "PlayerJump" && _animationComponentLegs.FinishedPlaying){
						_animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerInAirUp" , 20 , true);
					}
					else{
						_animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerInAirUp" , 20 , true);
					}
				}
			}
			else if(_yVelocity < 0){
				if(_animationComponentLegs == null) _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerInAirDown" , 20 , true);
				else if(_animationComponentLegs.Name != "PlayerInAirDown"){
					_animationComponentLegs = AnimationManager.Play(_view.PlayerLegs , "PlayerInAirUp" , 20 , true);
				}
			}
		}

		if(_collisionDetection.Grounded(transform.position , Vector2.one , _yVelocity) == false){
			if(_yVelocity > 0){
				AnimationManager.Play(_view.PlayerLegs , "PlayerInAirUp" , 0 , true);
				Debug.Log("PlayerInAirUp");
			}
			else{
				AnimationManager.Play(_view.PlayerLegs , "PlayerInAirDown" , 0 , true);
				Debug.Log("PlayerInAirUp");
			}
		}
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
