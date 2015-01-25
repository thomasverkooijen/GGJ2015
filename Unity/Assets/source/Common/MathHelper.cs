using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MathHelper{

	public static float IncrementTowards(float p_currentSpeed , float p_targetSpeed , float p_acceleration){
		if(p_currentSpeed == p_targetSpeed) return p_currentSpeed;
		float dir = Mathf.Sign(p_targetSpeed - p_currentSpeed);
		p_currentSpeed += p_acceleration * Time.deltaTime * dir;
		return (dir == Mathf.Sign(p_targetSpeed-p_currentSpeed))? p_currentSpeed : p_targetSpeed;
	}

	public static Vector2 GetCenterOfGroupOfObjects(List<GameObject> p_objects){
        p_objects.RemoveAll(go => go.GetComponent<CursorController>().enabled == true);
		float leftBoundX = float.PositiveInfinity;
		float rightBoundX = float.NegativeInfinity;
		float leftBoundY = float.PositiveInfinity;
		float rightBoundY = float.NegativeInfinity;
		foreach(GameObject g in p_objects){
			if (g.transform.position.x <= leftBoundX)	leftBoundX = g.transform.position.x;
			if (g.transform.position.x >= rightBoundX)	rightBoundX = g.transform.position.x;
			if (g.transform.position.y <= leftBoundY)	leftBoundY = g.transform.position.y;
			if (g.transform.position.y >= rightBoundY)	rightBoundY = g.transform.position.y;
		}
		float xCenter = (leftBoundX+rightBoundX)/2;
		float yCenter = (leftBoundY+rightBoundY)/2;
		return new Vector2(xCenter , yCenter);
	}

    public static GameObject GetClosestObjectInRange(List<GameObject> p_objects, Vector2 p_target, GameObject ignoredGameObject)
    {
        float smallestDistanceToTarget = float.PositiveInfinity;
        GameObject returnObject = null;
        foreach (GameObject g in p_objects)
        {
            if (g==ignoredGameObject)
            {
                continue;
            }
            if (Vector2.Distance(g.transform.position, p_target) <= smallestDistanceToTarget)
            {
                smallestDistanceToTarget = Vector2.Distance(g.transform.position, p_target);
                returnObject = g;
            }
        }
        return returnObject;
    }
}
