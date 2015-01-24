using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    CollisionDetection _collisionDetection = new CollisionDetection();

    [SerializeField]
    private float _maxSpeed, _acceleration;

    private float _xVelocity;
    private float _yVelocity;
    private Vector2 _velocity { get { return new Vector2(_xVelocity, _yVelocity); } }

    private Vector2 _position;

    void Update()
    {
        _position = transform.position;

        HandleHorizontalMovement();
        HandleVerticalMovement();

        if (_collisionDetection.Grounded) _yVelocity = 0;

        _yVelocity += GameSettings.Instance.Gravity * Time.deltaTime;
    }

    public void Move(float p_speed)
    {
        _xVelocity = p_speed * _maxSpeed;
    }

    public void Jump()
    {
        if (_collisionDetection.Grounded)
        {
            _yVelocity = 30;
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

}
