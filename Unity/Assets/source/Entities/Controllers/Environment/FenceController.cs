using UnityEngine;
using System.Collections;

public class FenceController : EnvironmentController {

    public GameObject ExplosionEffect;
    public BoxCollider2D Collider;
    public ParticleSystem Sparks;

    void Awake()
    {
        TogglePower(false);
    }

    public override void TogglePower(bool powerOn)
    {
        Powered = powerOn;
        if (Powered)
        {
            Sparks.Play();
            Collider.enabled = true;
        }
        else
        {
            Sparks.Stop();
            Collider.enabled = false;
        }
    }

    public virtual void OnHitByEntity(GameObject hittingObject)
    {
        if (Powered)
        {
            MovementController _movementController = hittingObject.GetComponent<MovementController>();
            if (_movementController != null)
            {
                //AnimationManager.Play(gameObject, "", 20, false);
                GameObject _launchEffect = Instantiate(ExplosionEffect, hittingObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(_launchEffect, _launchEffect.particleSystem.duration);
                GameManager.RemoveEntity(_movementController.gameObject);
            }
        }
    }
}
