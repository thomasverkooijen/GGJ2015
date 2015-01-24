﻿using UnityEngine;
using System.Collections;

public class CollisionDetection{

	private int rayCount = 6;
	private bool _grounded = false;
	public bool Grounded{get{return _grounded;}}

	public CollisionDetection(){
	}

	public float GetHorizontalMovement(Vector2 p_pos , Vector2 p_size , float p_xVelocity){
		for(int i = 0 ; i < rayCount ; i++){
			float xPos = p_pos.x + ((p_size.x/2)*Mathf.Sign(p_xVelocity));
			float yPos = p_pos.y + (p_size.y/2) - ((p_size.y/(rayCount-1))*i);

			if(i == 0)			yPos-=p_size.y/100;
			if(i == rayCount-1)	yPos+=p_size.y/100;
			
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos , yPos) , Vector2.right , p_xVelocity);
			if(hit){
				Debug.DrawRay(new Vector2(xPos , yPos) , Vector2.right*(hit.point.x - xPos));
				return hit.point.x-xPos;
			}
			else{
				Debug.DrawRay(new Vector2(xPos , yPos) , Vector2.right*p_xVelocity);
			}
		}
		return p_xVelocity;
	}

	public float GetVerticalMovement(Vector2 p_pos , Vector2 p_size , float p_yVelocity){
		_grounded = false;
		for(int i = 0 ; i < rayCount ; i++){
			float xPos = p_pos.x + (p_size.x/2) - ((p_size.x/(rayCount-1))*i);
			float yPos = p_pos.y + ((p_size.y/2)*Mathf.Sign(p_yVelocity));

			if(i == 0) 			xPos-=p_size.x/100;
			if(i == rayCount-1)	xPos+=p_size.x/100;

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos , yPos) , Vector2.up , p_yVelocity);
			if(hit){
				Debug.DrawRay(new Vector2(xPos , yPos) , Vector2.up*(hit.point.x - xPos));
				_grounded = true;
				return hit.point.x-xPos;
			}
			else{
				Debug.DrawRay(new Vector2(xPos , yPos) , Vector2.up*p_yVelocity);
			}
		}
		return p_yVelocity;
	}

}
