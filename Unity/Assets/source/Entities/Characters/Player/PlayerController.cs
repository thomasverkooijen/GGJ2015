using UnityEngine;
using System.Collections;

public class PlayerController : MovementController
{

    protected PlayerView _view;

    private AnimationComponent _animationComponentLegs;
    private AnimationComponent _animationComponentHead;

    private float _talkCounter = 0;
    private float _randomTalkCounter = 0;

    private float _footstepCounter = 0;
    private float _maxfootstepCounter = 1;

    private float _landingCounter = 0;

    public void Deactivate()
    {
        if (_view != null)
        {
            _view.Deactivate();
            this.enabled = false;
        }
    }

    public void Activate()
    {
        if (_view != null)
        {
            _view.Activate();
            this.enabled = true;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _controllerInputController.OnStickActive += HandleOnStickActive;
        _controllerInputController.OnStickNotActive += HandleOnStickNotActive;
        _controllerInputController.OnButtonPressed += HandleOnButtonPressed;
        _model = gameObject.GetComponent<Player>() as Player;
        _view = gameObject.GetComponent<PlayerView>();
        _randomTalkCounter = Random.Range(5 , 80);
    }



    protected override void Start()
    {
        base.Start();
        _animationComponentHead = AnimationManager.Play(_view.PlayerHead, "HeadOneWalk", 0, true);
        _animationComponentHead.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Head";
        _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerMovement", 0, true);
        _animationComponentLegs.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Legs";
    }

    protected override void Update()
    {
        base.Update();
        bool _prevOnGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f, gameObject);

        HandleHorizontalMovement();
        HandleVerticalMovement();
        bool _onGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f, gameObject);
        float _tempYVelocity = _yVelocity;
        HandleGravity();
        HandleObstructions();
        HandleAnimations();
        HandleFootsteps();
        //HandleTalking();
        _landingCounter += Time.deltaTime;
        if (_prevOnGround == false && _onGround == true && _landingCounter > 0.5f)
        {
            _landingCounter = 0;
            HandleLanding(_tempYVelocity);
        }
    }

    void HandleLanding(float speed)
    {
        /*AudioSource s = AudioManager.Play(null, false, "Landing");
        if (s != null)
        {
            s.volume = 0 - (speed / 75);
        }
        */
    }

    void HandleTalking()
    {
        _talkCounter += Time.deltaTime;
        if (_talkCounter > _randomTalkCounter)
        {
            _talkCounter = 0;
            _randomTalkCounter = Random.Range(30, 80);
			Debug.Log("Play talk");
            AudioManager.Play(null, false, "Talk");
        }
    }

    void HandleFootsteps()
    {
        bool _onGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f);
        if (!_onGround) return;
        float currentMaxTimer = (_maxfootstepCounter / Mathf.Abs(_xVelocity));
        _footstepCounter += Time.deltaTime;
        if (_footstepCounter > currentMaxTimer)
        {
            _footstepCounter = 0;
            AudioManager.Play(null, false, "Footstep");
        }
    }

    void HandleAnimations()
    {

        if (_xVelocity > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (_xVelocity < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        bool _onGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f, gameObject);

        if (!_onGround)
        {

            _animationComponentHead = AnimationManager.Play(_view.PlayerHead, "HeadOneWalk", 0, true);

            if (_yVelocity > 0)
            {
                if (_animationComponentLegs == null) _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerInAirUp", 20, true);
                else if (_animationComponentLegs.Name != "PlayerInAirUp")
                {
                    if (_animationComponentLegs.Name == "PlayerJump" && _animationComponentLegs.FinishedPlaying)
                    {
                        _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerInAirUp", 20, true);
                    }
                    else
                    {
                        _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerInAirUp", 20, true);
                    }
                }
            }
            else if (_yVelocity < 0)
            {
                if (_animationComponentLegs == null) _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerInAirDown", 20, true);
                else if (_animationComponentLegs.Name != "PlayerInAirDown")
                {
                    _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerInAirDown", 20, true);
                }
            }
        }
        else
        {
            if (_animationComponentHead == null) _animationComponentHead = AnimationManager.Play(_view.PlayerHead, "HeadOneWalk", 20, true);
            else if (_animationComponentHead.Name != "HeadOneWalk")
            {
        		_animationComponentHead = AnimationManager.Play(_view.PlayerHead, "HeadOneWalk", 20, true);
			}

           	if (_animationComponentLegs == null) _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerMovement", 20, true);
            else if (_animationComponentLegs.Name != "PlayerMovement")
	        {
	        	_animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerMovement", 20, true);
            }
			AnimationManager.SetFps(_view.PlayerLegs, "PlayerMovement", Mathf.Abs((int)(_xVelocity * Time.deltaTime * 500)));
			AnimationManager.SetFps(_view.PlayerHead, "HeadOneWalk", Mathf.Abs((int)(_xVelocity * Time.deltaTime * 500)));
        }
    }

    void HandleOnButtonPressed(ControllerButton p_controllerButton, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_controllerButton)
        {
            case ControllerButton.A:
                bool _onGround = _collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f);
                if (_onGround)
                {
                    Jump();
                    AudioSource s = AudioManager.Play(null, false , "PlayerJump");
                    s.pitch += _yVelocity / 30;
                    _animationComponentLegs = AnimationManager.Play(_view.PlayerLegs, "PlayerJump", 20, true);
                }
                break;
        }
    }

    void HandleOnStickActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_stickType)
        {
            case StickType.LeftX:
                _xVelocity = MathHelper.IncrementTowards(_xVelocity, p_speed * _maxSpeed, _acceleration);
                break;
        }
    }
    void HandleOnStickNotActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_stickType)
        {
            case StickType.LeftX:
                _xVelocity = MathHelper.IncrementTowards(_xVelocity, 0, _acceleration);
                break;
        }
    }
}