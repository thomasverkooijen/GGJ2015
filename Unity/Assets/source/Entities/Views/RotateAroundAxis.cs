using UnityEngine;
using System.Collections;

public class RotateAroundAxis : MonoBehaviour {

    private Vector3 Axis = Vector3.forward;
    public float speed = 20.0f;
	
	void Update () {
        transform.Rotate(Axis, speed * Time.deltaTime, Space.Self);
	}
}
