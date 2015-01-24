using UnityEngine;
using System.Collections;

public class GameSettings : Singleton<GameSettings>
{
    public GameObject AudioLibraryPrefab;
	public GameObject AnimationLibraryPrefab;
	public GameObject EntityLibraryPrefab;

    public float Gravity;

    void Awake(){
        AudioLibrary.Init(AudioLibraryPrefab);
		AnimationLibrary.Init(AnimationLibraryPrefab);
		EntityLibrary.Init(EntityLibraryPrefab);
    }
}
