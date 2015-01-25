using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour {

	private static readonly Dictionary<string, AnimationLibraryItem> _animationDictionary = new Dictionary<string, AnimationLibraryItem>();

	public static void AddAnimation(string p_name , AnimationLibraryItem item){
		if(_animationDictionary.ContainsKey(p_name)){
			Debug.Log("Animation with name("+p_name+") already exists");
			return;
		}
		_animationDictionary[p_name] = item;
	}

	public static AnimationComponent Play(GameObject p_target , string p_animationName , int p_fps , bool p_isLoop){
		if(!_animationDictionary.ContainsKey(p_animationName)){
			Debug.Log("[AnimationManager] : Animation event ("+p_animationName+") was not found");
			return null;
		}
		AnimationComponent animationComponent = p_target.GetComponent<AnimationComponent>();
		if(animationComponent == null){
			animationComponent = p_target.AddComponent<AnimationComponent>();
		}
		animationComponent.Name		= p_animationName;
		animationComponent.sprites	= _animationDictionary[p_animationName].Sprites;
		animationComponent.loop		= p_isLoop;
		animationComponent.fps		= p_fps;
		animationComponent.Reset();
		return animationComponent;
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
