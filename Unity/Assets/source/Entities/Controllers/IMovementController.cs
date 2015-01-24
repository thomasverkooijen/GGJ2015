using UnityEngine;
using System.Collections;

public interface IMovementController{
    void Move(float p_speed);
    void Move(float p_horizontal_speed, float p_vertical_speed);
    void Jump();
    void HandleHorizontalMovement();
    void HandleVerticalMovement();
    void HandleDrag();
}
