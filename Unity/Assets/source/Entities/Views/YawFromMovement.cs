using UnityEngine;
using System.Collections;

public class YawFromMovement : MonoBehaviour {

    Vector3 previousPosition;
    float yawMultiplier = 200.0f;

	void Update () {
        Vector3 difference = previousPosition - transform.position;
        transform.localRotation = Quaternion.Euler(0, 0, difference.magnitude * yawMultiplier * Mathf.Sign(difference.x));
        previousPosition = transform.position;
	}
}
