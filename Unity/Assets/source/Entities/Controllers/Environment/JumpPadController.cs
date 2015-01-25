using UnityEngine;
using System.Collections;

public class JumpPadController : EnvironmentController
{
    public float LaunchStrength = 30;

    public GameObject LaunchEffect;

    public float Cooldown = 2.5f;
    private float _cooldownTimer = 3.0f;

    void Update()
    {
        _cooldownTimer += Time.deltaTime;

    }

    //public void OnHitByEntity()
    //{
    //    Debug.Log("Can not launch! No game object passed!");
    //}

    public override void OnHitByEntity(GameObject hittingObject)
    {
        if (_cooldownTimer > Cooldown)
        {
            MovementController _movementController = hittingObject.GetComponent<MovementController>();
            if (_movementController != null)
            {
                //AnimationManager.Play(gameObject, "", 20, false);
                GameObject _launchEffect = Instantiate(LaunchEffect, hittingObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(_launchEffect, _launchEffect.particleSystem.duration);
                _movementController.Launch(LaunchStrength);
                _cooldownTimer = 0.0f;
            }
        }
    }

}
