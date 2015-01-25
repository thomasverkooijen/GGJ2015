using UnityEngine;
using System.Collections;

public class PressurePadController : EnvironmentController
{
    public EnvironmentController TargetProp;
    public bool IsInverted = false;

    void LateUpdate()
    {
        if (Powered)
        {
            if (IsInverted)
            {
                TargetProp.TogglePower(false);
            }
            else
            {
                TargetProp.TogglePower(true);
            }
        }
        else
        {
            if (IsInverted)
            {
                TargetProp.TogglePower(true);
            }
            else
            {
                TargetProp.TogglePower(false);
            }
        }
        Powered = false;
    }

    public override void OnHitByEntity(GameObject hittingObject)
    {
        Powered = true;
    }
}
