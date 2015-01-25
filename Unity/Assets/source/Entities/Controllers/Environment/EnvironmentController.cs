using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {

    public virtual void OnHitByEntity(GameObject hittingObject)
    {
        Debug.LogWarning("Hit EnvironmentController, derive from EnvironmentController and implement some behaviour.");
    }
}
