using UnityEngine;
using System.Collections;

public class MovementModel : MonoBehaviour, IModel
{
    public float JumpSpeed = 15.0f;
    public float AirControl = 0.75f;
    public float HorizontalDrag = 0.9f;
    public float VerticalDrag = 1.0f;
}
