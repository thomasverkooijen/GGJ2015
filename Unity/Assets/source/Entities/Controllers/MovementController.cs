using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour, IController
{

    CollisionDetection _collisionDetection = new CollisionDetection();

    [SerializeField]
    private float _maxSpeed, _acceleration;

    private float _xVelocity;
    private float _yVelocity;
    private Vector2 _velocity { get { return new Vector2(_xVelocity, _yVelocity); } }

    private Vector2 _position;

    private MovementModel _movementModel;

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
        HandleHorizontalDrag();

        if (_collisionDetection.Grounded) _yVelocity = 0;

        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
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

    public void Jump()
    {
        if (_collisionDetection.Grounded)
        {
            _yVelocity = _movementModel.JumpSpeed;
        }
    }

    private void HandleHorizontalMovement()
    {
        float addedX = _collisionDetection.GetHorizontalMovement(transform.position, Vector2.one, _xVelocity * Time.deltaTime);
        transform.Translate(Vector2.right * addedX);
    }

    private void HandleVerticalMovement()
    {
        float addedY = _collisionDetection.GetVerticalMovement(transform.position, Vector2.one, _yVelocity * Time.deltaTime);
        transform.Translate(Vector2.up * addedY);
    }

    private void HandleHorizontalDrag()
    {
        _xVelocity *= (_movementModel.HorizontalDrag * Time.deltaTime);
    }
}
