using UnityEngine;
using System.Collections;

public class FinishController : EnvironmentController
{
    public override void OnHitByEntity(GameObject hittingObject)
    {
        GameProgressTracker.ObjectFinished(hittingObject);
    }
}
