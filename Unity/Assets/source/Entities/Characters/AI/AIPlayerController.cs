using UnityEngine;
using System.Collections;

public class AIPlayerController : MovementController {

	protected AIPlayerView _view;
	
	protected override void Awake(){
		base.Awake();
		_model 	= gameObject.GetComponent<AIplayer>() as AIplayer;
		_view	= gameObject.GetComponent<AIPlayerView>();
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

}
