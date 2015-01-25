using UnityEngine;
using System.Collections;
using Assets.source.Entities.Characters.AI;

public class AIPlayerController : MovementController {

    private AIState AIState = AIState.Idle;
    private float AIDecisionDelay = 0.25f;
	protected AIPlayerView _view;
	
	protected override void Awake(){
		base.Awake();
		_model 	= gameObject.GetComponent<AIplayer>() as AIplayer;
		_view	= gameObject.GetComponent<AIPlayerView>();
        StartCoroutine(ChangeState());
	}

    IEnumerator ChangeState()
    {
        float _decisionValue = Random.value;
        if (_decisionValue <= 0.2f)
        {
            AIState = AIState.Idle;
        }
        if (_decisionValue > 0.2f && _decisionValue <= 0.4f)
        {
            AIState = AIState.MoveLeft;
        }
        if (_decisionValue > 0.4f)
        {
            AIState = AIState.MoveRight;
        }
        _decisionValue = Random.value;
        if(_decisionValue>0.75f)
        {
            Jump();
        }
        yield return new WaitForSeconds(AIDecisionDelay);
        StartCoroutine(ChangeState());
    }

    private void HandleAI()
    {
        switch(AIState)
        {
            case AIState.Idle:
                Idle();
                break;
            case AIState.MoveLeft:
                MoveLeft(-1.0f);
                break;
            case AIState.MoveRight:
                MoveRight(1.0f);
                break;
        }
    }

    private void Idle()
    {
        _xVelocity = MathHelper.IncrementTowards(_xVelocity, 0.0f, _acceleration);
    }

    private void MoveRight(float p_speed)
    {
        _xVelocity = MathHelper.IncrementTowards(_xVelocity, p_speed * _maxSpeed, _acceleration);
    }

    private void MoveLeft(float p_speed)
    {
        _xVelocity = MathHelper.IncrementTowards(_xVelocity, p_speed * _maxSpeed, _acceleration);
    }

    private void AIJump()
    {
        Jump();
    }

	protected override void Start (){
		base.Start ();
		//AnimationManager.Play(_view.PlayerHead , "PlayerHeadWalk" , 0 , true);
		//AnimationManager.Play(_view.PlayerLegs , "PlayerLegsWalk" , 0 , true);
	}
	
	protected override void Update(){
		base.Update();
        HandleAI();
		HandleHorizontalMovement();
		HandleVerticalMovement();
		HandleGravity();
		HandleObstructions();
		//AnimationManager.SetFps(_view.PlayerLegs , "PlayerLegsWalk" , (int)(_xVelocity*450*Time.deltaTime));

	}

}
