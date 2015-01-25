using UnityEngine;
using System.Collections;

public class CollisionDetection{

	private int rayCount = 6;
	private bool _obstructed = false;
	private GameObject _groundObject;
	private GameObject _obstructingObject;

	public bool Obstructed{get{return _obstructed;}}
	public GameObject GroundObject{get{return _groundObject;}}
	public GameObject ObstructingObject{get{return _obstructingObject;}}

	public CollisionDetection(){
	}

	public bool Grounded(Vector2 p_pos , Vector2 p_size , float checkDist){
		for(int i = 0 ; i < rayCount ; i++){
			float xPos = p_pos.x + (p_size.x/2) - ((p_size.x/(rayCount-1))*i);
			float yPos = p_pos.y + ((p_size.y/2)*Mathf.Sign(checkDist));
			
			if(i == 0) 			xPos-=p_size.x/100;
			if(i == rayCount-1)	xPos+=p_size.x/100;

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos , yPos) , Vector2.up , checkDist);
            if (hit)
            {
                _groundObject = hit.collider.gameObject;
                _groundObject.BroadcastMessage("OnHitByEntity", null, SendMessageOptions.DontRequireReceiver);
                return true;
            }
		}
		return false;
	}

	public float GetHorizontalMovement(Vector2 p_pos , Vector2 p_size , float p_xVelocity){
		_obstructed = false;
		for(int i = 0 ; i < rayCount ; i++){
			float xPos = p_pos.x + ((p_size.x/2)*Mathf.Sign(p_xVelocity));
			float yPos = p_pos.y + (p_size.y/2) - ((p_size.y/(rayCount-1))*i);

			if(i == 0)			yPos-=p_size.y/100;
			if(i == rayCount-1)	yPos+=p_size.y/100;
			
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos , yPos) , Vector2.right , p_xVelocity);
			if(hit){
				_obstructed = true;
				_obstructingObject = hit.collider.gameObject;
                _obstructingObject.BroadcastMessage("OnHitByEntity", null, SendMessageOptions.DontRequireReceiver);
				return hit.point.x-xPos;
			}
		}
		return p_xVelocity;
	}

	public float GetVerticalMovement(Vector2 p_pos , Vector2 p_size , float p_yVelocity){
		for(int i = 0 ; i < rayCount ; i++){
			float xPos = p_pos.x + (p_size.x/2) - ((p_size.x/(rayCount-1))*i);
			float yPos = p_pos.y + ((p_size.y/2)*Mathf.Sign(p_yVelocity));

			if(i == 0) 			xPos-=p_size.x/100;
			if(i == rayCount-1)	xPos+=p_size.x/100;

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos , yPos) , Vector2.up , p_yVelocity);
			if(hit){
				_groundObject = hit.collider.gameObject;
				return hit.point.x-xPos;
			}
		}
		return p_yVelocity;
	}

    public bool Grounded(Vector2 p_pos, Vector2 p_size, float checkDist, GameObject sender)
    {
        for (int i = 0; i < rayCount; i++)
        {
            float xPos = p_pos.x + (p_size.x / 2) - ((p_size.x / (rayCount - 1)) * i);
            float yPos = p_pos.y + ((p_size.y / 2) * Mathf.Sign(checkDist));

            if (i == 0) xPos -= p_size.x / 100;
            if (i == rayCount - 1) xPos += p_size.x / 100;

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos, yPos), Vector2.up, checkDist);
            if (hit)
            {
                _groundObject = hit.collider.gameObject;
                _groundObject.BroadcastMessage("OnHitByEntity", sender, SendMessageOptions.DontRequireReceiver);
                return true;
            }
        }
        return false;
    }

    public float GetHorizontalMovement(Vector2 p_pos, Vector2 p_size, float p_xVelocity, GameObject sender)
    {
        _obstructed = false;
        for (int i = 0; i < rayCount; i++)
        {
            float xPos = p_pos.x + ((p_size.x / 2) * Mathf.Sign(p_xVelocity));
            float yPos = p_pos.y + (p_size.y / 2) - ((p_size.y / (rayCount - 1)) * i);

            if (i == 0) yPos -= p_size.y / 100;
            if (i == rayCount - 1) yPos += p_size.y / 100;

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos, yPos), Vector2.right, p_xVelocity);
            if (hit)
            {
                _obstructed = true;
                _obstructingObject = hit.collider.gameObject;
                _obstructingObject.BroadcastMessage("OnHitByEntity", sender, SendMessageOptions.DontRequireReceiver);
                return hit.point.x - xPos;
            }
        }
        return p_xVelocity;
    }

    public float GetVerticalMovement(Vector2 p_pos, Vector2 p_size, float p_yVelocity, GameObject sender)
    {
        for (int i = 0; i < rayCount; i++)
        {
            float xPos = p_pos.x + (p_size.x / 2) - ((p_size.x / (rayCount - 1)) * i);
            float yPos = p_pos.y + ((p_size.y / 2) * Mathf.Sign(p_yVelocity));

            if (i == 0) xPos -= p_size.x / 100;
            if (i == rayCount - 1) xPos += p_size.x / 100;

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos, yPos), Vector2.up, p_yVelocity);
            if (hit)
            {
                _groundObject = hit.collider.gameObject;
                return hit.point.x - xPos;
            }
        }
        return p_yVelocity;
    }
}
