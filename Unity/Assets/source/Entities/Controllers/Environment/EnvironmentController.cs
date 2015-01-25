using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {

    public bool Powered = false;

    public virtual void TogglePower(bool powerOn)
    {
        Powered = powerOn;
    }

    public virtual void OnHitByEntity(GameObject hittingObject)
    {
        Debug.LogWarning("Hit EnvironmentController, derive from EnvironmentController and implement some behaviour.");
    }

    public void TogglePower()
    {
        Powered = !Powered;
    }
}
