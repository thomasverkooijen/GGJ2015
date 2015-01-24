using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float LerpSpeed = 0.5f;
    
    void LateUpdate () {
        Vector3 newTargetPosition = Vector3.zero;
        newTargetPosition.z = -10;
        newTargetPosition.x = EntityManager.Instance.FindCenterOfActiveEntities();
        transform.position = Vector3.Lerp(transform.position, newTargetPosition, LerpSpeed*Time.deltaTime);
	}
}
