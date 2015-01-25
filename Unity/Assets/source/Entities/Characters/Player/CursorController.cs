using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorController : MovementController
{
    public GameObject LaserBeam;
    protected CursorView _view;
    protected GameObject M06;

    private float _talkCounter = 0;
    private float _randomTalkCounter = 0;
    private float AcquisitionRange = 2.5f;
    public GameObject ExplosionPrefab;

    public void Activate()
    {
        if (_view != null)
        {
            _view.Activate();
            this.enabled = true;
        }
        M06 = GameObject.FindGameObjectWithTag("M06");
        M06.GetComponent<MoveAlongTarget>().SetTarget(this.gameObject);
    }

    public void Deactivate()
    {
        if (_view != null)
        {
            _view.Deactivate();
            this.enabled = false;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _controllerInputController.OnStickActive += HandleOnStickActive;
        _controllerInputController.OnStickNotActive += HandleOnStickNotActive;
        _controllerInputController.OnButtonPressed += HandleOnButtonPressed;
        _model = gameObject.GetComponent<Player>() as Player;
        _view = gameObject.GetComponent<CursorView>();
        _randomTalkCounter = Random.Range(5, 30);
        M06 = GameObject.FindGameObjectWithTag("M06");
    }

    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

        HandleHorizontalMovement();
        HandleVerticalMovement();

        //float _tempYVelocity = _yVelocity;
        //HandleGravity();
        //HandleObstructions();
        //HandleAnimations();
        HandleTalking();
    }

    protected void HandleHorizontalMovement()
    {
        float addedX = _xVelocity * Time.deltaTime;
        transform.Translate(Vector2.right * addedX);
    }

    protected void HandleVerticalMovement()
    {
        float addedY = _yVelocity * Time.deltaTime;
        transform.Translate(Vector2.up * addedY);
    }

    void HandleTalking()
    {
        _talkCounter += Time.deltaTime;
        if (_talkCounter > _randomTalkCounter)
        {
            _talkCounter = 0;
            _randomTalkCounter = Random.Range(5, 30);
            AudioManager.Play(gameObject, true, "Talk");
        }
    }

    void HandleAnimations()
    {

    }

    void HandleOnButtonPressed(ControllerButton p_controllerButton, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_controllerButton)
        {
            case ControllerButton.A:
                PerformAction();
                break;
        }
    }

    private void PerformAction()
    {
        RaycastHit2D raycastHitInfo = Physics2D.Raycast(transform.position, Vector2.zero);
        if (raycastHitInfo.collider!=null)
        {
            Debug.Log(raycastHitInfo.collider.gameObject.name);
        }
        else
        {
            GameObject targetObject = MathHelper.GetClosestObjectInRange(GameManager.ActiveEntities, transform.position, this.gameObject);
            float distanceToTarget = Vector2.Distance(targetObject.transform.position, transform.position);
            if (distanceToTarget<=AcquisitionRange)
            {
                Vector3 beamLocation = MathHelper.GetCenterOfGroupOfObjects(new List<GameObject>{
                        M06,
                        targetObject}
                    );
                beamLocation.z = -3.0f;
                GameObject newBeam = GameObject.Instantiate(LaserBeam, beamLocation, Quaternion.identity) as GameObject;
                ParticleSystem beamSystem = newBeam.GetComponent<ParticleSystem>();
                Vector2 fromM06ToTarget = targetObject.transform.position - M06.transform.position;
                fromM06ToTarget.Normalize();
                newBeam.transform.localScale = new Vector3(0.0f, 0.0f, Vector2.Distance(targetObject.transform.position, M06.transform.position));
                newBeam.transform.rotation = Quaternion.LookRotation(fromM06ToTarget);
                GameObject explosion = GameObject.Instantiate(ExplosionPrefab, targetObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().duration);
                Destroy(newBeam, newBeam.GetComponent<ParticleSystem>().duration);
                GameManager.RemoveEntity(targetObject);   
            }
        }
    }

    void HandleOnStickActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_stickType)
        {
            case StickType.LeftX:
                _xVelocity = p_speed * _maxSpeed;
                break;
            case StickType.LeftY:
                _yVelocity = p_speed * _maxSpeed;
                break;
        }
    }
    void HandleOnStickNotActive(StickType p_stickType, float p_speed, int p_playerIndex)
    {
        if (_model.EntityID != p_playerIndex) return;
        switch (p_stickType)
        {
            case StickType.LeftX:
                _xVelocity =0;//= MathHelper.IncrementTowards(_xVelocity, 0, _acceleration*2);
                break;
            case StickType.LeftY:
                _yVelocity = 0;//MathHelper.IncrementTowards(_yVelocity, 0, _acceleration*2);
                break;
        }
    }
}