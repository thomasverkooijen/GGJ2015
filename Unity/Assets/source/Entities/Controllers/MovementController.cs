using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour, IMovementController
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
        HandleDrag();

        if (_collisionDetection.Grounded) _yVelocity = 0;

        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
		AnimationManager.SetFps(gameObject , "WalkAnim" , (int)(_xVelocity*500));
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

    public void HandleHorizontalMovement()
    {
        float addedX = _collisionDetection.GetHorizontalMovement(transform.position, Vector2.one, _xVelocity * Time.deltaTime);
        transform.Translate(Vector2.right * addedX);
    }

    public void HandleVerticalMovement()
    {
        float addedY = _collisionDetection.GetVerticalMovement(transform.position, Vector2.one, _yVelocity * Time.deltaTime);
        transform.Translate(Vector2.up * addedY);
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
