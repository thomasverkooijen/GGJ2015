using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float LerpSpeed = 0.9f;
    
    void LateUpdate () {
        Vector3 newTargetPosition = Vector3.zero;
        newTargetPosition = MathHelper.GetCenterOfGroupOfObjects(GameManager.ActiveEntities);
        newTargetPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, newTargetPosition, LerpSpeed*Time.deltaTime);
		transform.position = new Vector2(transform.position.x , 0);
		Vector2 sizeOfGroup = MathHelper.GetSizeOfGroupOfObjects(GameManager.ActiveEntities);
		//Camera.main.orthographicSize = sizeOfGroup.x > sizeOfGroup.y ? sizeOfGroup.y : sizeOfGroup.x;
	}
}
