using UnityEngine;
using System.Collections;

public class AnimationComponent : MonoBehaviour {
	
	private SpriteRenderer	_spriteRenderer;
	private int				_frames;
	private float 			_currentFrame = 0;

	public string	Name;
	public Sprite[] sprites;
	public bool		loop = true;
	public float	fps  = 20;
	public bool		FinishedPlaying = false;

	public void Reset(){
		FinishedPlaying = false;
		_currentFrame = 0;
	}


	void Awake(){
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		if(_spriteRenderer == null){
			_spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		}
	}

	void Update(){
		_frames = sprites.Length;

		_currentFrame += Time.deltaTime*fps;

		if(fps>=0){
			if(loop && Mathf.Floor(_currentFrame) > _frames-1){
				_currentFrame = 0;
			}
			else if(!loop && Mathf.Floor(_currentFrame) < 0){
				_currentFrame = _frames-1;
				FinishedPlaying = true;
			}
		}
		else{
			if(loop && Mathf.Floor(_currentFrame) < 0){
				_currentFrame = _frames-1;
			}
			else if(!loop && Mathf.Floor(_currentFrame) < 0){
				_currentFrame = 0;
				FinishedPlaying = true;
			}
		}
		_spriteRenderer.sprite = sprites[(int)Mathf.Floor(_currentFrame)];
	}

}
