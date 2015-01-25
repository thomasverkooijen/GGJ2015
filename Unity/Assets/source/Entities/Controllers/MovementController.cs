using UnityEngine;
using System.Collections;

public abstract class MovementController : EventContainerBase, IMovementController
{
    [SerializeField]
    protected float _maxSpeed, _acceleration, _jumpForce;

    protected CollisionDetection _collisionDetection = new CollisionDetection();
    protected Entity _model;
    protected float _xVelocity;
    protected float _yVelocity;
    protected Vector2 _velocity { get { return new Vector2(_xVelocity, _yVelocity); } }

    protected ControllerInputEventController _controllerInputController;

    private Vector2 _position;

    private MovementModel _movementModel;

    protected override void Awake()
    {
        _controllerInputController = new ControllerInputEventController(this);
        AddController(_controllerInputController);
        base.Awake();
    }

    protected void HandleHorizontalMovement()
    {
        float addedX = _collisionDetection.GetHorizontalMovement(transform.position, Vector2.one, _xVelocity * Time.deltaTime);
        transform.Translate(Vector2.right * addedX);
    }

    protected void HandleVerticalMovement()
    {
        float addedY = _collisionDetection.GetVerticalMovement(transform.position, Vector2.one, _yVelocity * Time.deltaTime);
        transform.Translate(Vector2.up * addedY);
    }

    protected void HandleGravity()
    {
        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
        if (_collisionDetection.Grounded(transform.position, Vector2.one, _yVelocity * Time.deltaTime)) _yVelocity = 0;
    }
    protected void HandleObstructions()
    {
        if (_collisionDetection.Obstructed) _xVelocity = 0;
    }

    protected void Jump()
    {
        if (_collisionDetection.Grounded(transform.position, Vector2.one, (_yVelocity * Time.deltaTime) - 0.1f))
        {
            _yVelocity = _jumpForce;
        }
    }


    void Start()
    {
        _movementModel = GetComponent<MovementModel>();
        if (_movementModel == null)
        {
            throw new MissingComponentException(gameObject.name + " has no _movementModel, have you forgotten to add one manually?");
        }
    }


    void Update()
    {
        _position = transform.position;

        HandleHorizontalMovement();
        HandleVerticalMovement();
        HandleDrag();

        if (_collisionDetection.Grounded) _yVelocity = 0;

        HandleCollision();

        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
        AnimationManager.SetFps(gameObject, "WalkAnim", (int)(_xVelocity * 500));
    }

    public void HandleCollision()
    {
        if (_collisionDetection.ObstructingObject != null)
        {
            HandleCollisionForObject(_collisionDetection.ObstructingObject);
        }
        if (_collisionDetection.GroundObject != null)
        {
            HandleCollisionForObject(_collisionDetection.GroundObject);
        }
    }

    public void HandleCollisionForObject(GameObject collidingObject)
    {
        switch (collidingObject.tag)
        {
            case null:
                break;
            case "Finish":
                Finish();
                break;
            case "Environmental":
                HandleEnvironmental(collidingObject);
                break;
        }
    }

    private void HandleEnvironmental(GameObject environmental)
    {
        Debug.Log("Should handle code for " + environmental.name + " here.");
    }

    public void Finish()
    {
        EntityManager.Instance.EntityFinishes(this.gameObject);
    }

    public void Move(float p_speed)
    {
        if (_collisionDetection.Grounded)
        {
            _xVelocity += p_speed * _maxSpeed;
        }
        else
        {
            _xVelocity += (p_speed * _movementModel.AirControl) * _maxSpeed;
        }
    }

    public void HandleDrag()
    {
        _xVelocity *= (_movementModel.HorizontalDrag * Time.deltaTime);
        //_yVelocity *= (_movementModel.VerticalDrag * Time.deltaTime);
    }


    public void Move(float p_horizontal_speed, float p_vertical_speed)
    {
        _xVelocity += p_horizontal_speed * _maxSpeed;
        _yVelocity += p_vertical_speed * _maxSpeed;
    }
}