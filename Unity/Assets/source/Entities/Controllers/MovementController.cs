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
        float addedX = _collisionDetection.GetHorizontalMovement(transform.position, Vector2.one, _xVelocity * Time.deltaTime, gameObject);
        transform.Translate(Vector2.right * addedX);
    }

    protected void HandleVerticalMovement()
    {
        float addedY = _collisionDetection.GetVerticalMovement(transform.position, Vector2.one, _yVelocity * Time.deltaTime, gameObject);
        transform.Translate(Vector2.up * addedY);
    }

    protected void HandleGravity()
    {
        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
        if (_collisionDetection.Grounded(transform.position, Vector2.one, _yVelocity * Time.deltaTime, gameObject)) _yVelocity = 0;
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

}