using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour {

	private static readonly Dictionary<string, Sprite[]> _animationDictionary = new Dictionary<string, Sprite[]>();

	public static void AddAnimation(string p_name , Sprite[] p_sprites){
		if(_animationDictionary.ContainsKey(p_name)){
			Debug.Log("Animation with name("+p_name+") already exists");
			return;
		}
		_animationDictionary[p_name] = p_sprites;
	}

	public static void Play(GameObject p_target , string p_animationName , int p_fps , bool p_isLoop){
		if(!_animationDictionary.ContainsKey(p_animationName)){
			Debug.Log("[AnimationManager] : Animation event ("+p_animationName+") was not found");
			return;
		}
		AnimationComponent animationComponent = p_target.GetComponent<AnimationComponent>();
		if(animationComponent == null){
			animationComponent = p_target.AddComponent<AnimationComponent>();
		}
		animationComponent.sprites	= _animationDictionary[p_animationName];
		animationComponent.loop		= p_isLoop;
		animationComponent.fps		= p_fps;
		animationComponent.Reset();
	}

	public static void SetFps(GameObject p_target , string p_animationName , int p_fps){
		if(!_animationDictionary.ContainsKey(p_animationName)){
			Debug.Log("[AnimationManager] : Animation event ("+p_animationName+") was not found");
			return;
		}
		AnimationComponent animationComponent = p_target.GetComponent<AnimationComponent>();
		if(animationComponent == null){
			Debug.Log("[AnimationManager] : Cant set fps of non existing Animation("+p_animationName+")");
			return;
		}
		animationComponent.fps		= p_fps;
	}
}
