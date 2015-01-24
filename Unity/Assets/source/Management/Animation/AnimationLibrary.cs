﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class AnimationLibraryItem{
	public string 	AnimationName;
	public Sprite[]	Sprites;
}

public class AnimationLibrary : MonoBehaviour {

	public static bool Initiated = false;

	[SerializeField] private string LibraryName;

	public AnimationLibraryItem[] animationLibraryItems;

	public static void Init(GameObject animationLibraryPrefab){
		if(Initiated) return;
		if(animationLibraryPrefab == null){
			Debug.Log("[AnimationLibrary] -> Init : Initiate failed because animationLibraryPrefab is null");
			return;
		}
		Initiated = true;
		GameObject animationLibrary = GameObject.Find("_AnimationLibrary");
		if (animationLibrary != null) Destroy(animationLibrary);
		
		GameObject newAudioLibrary = Instantiate(animationLibraryPrefab) as GameObject;
		newAudioLibrary.name = "_AnimationLibrary";
	}

	void Start(){
		Debug.Log("[AnimationLibrary] (" + LibraryName + ") Filling Library");
		foreach(AnimationLibraryItem item in animationLibraryItems){
			AnimationManager.AddAnimation(item.AnimationName , item.Sprites);
		}
	}

	void Awake(){
		DontDestroyOnLoad( gameObject );	
	}
}
