using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float LerpSpeed = 0.5f;
    
    void LateUpdate () {
        Vector3 newTargetPosition = Vector3.zero;
        newTargetPosition = MathHelper.GetCenterOfGroupOfObjects(GameManager.ActiveEntities);
        newTargetPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, newTargetPosition, LerpSpeed*Time.deltaTime);
	}
}
