using UnityEngine;
using System.Collections;

public class MovementModel : MonoBehaviour, IModel
{
    public float JumpSpeed { get { return GameSettings.Instance.JumpSpeedBase; } set { this.JumpSpeed = value; } }
    public float AirControl = 0.75f;
    public float HorizontalDrag = 0.9f;
}
