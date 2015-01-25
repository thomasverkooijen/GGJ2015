using UnityEngine;
using System.Collections;

public class GameSettings : Singleton<GameSettings>
{
    public GameObject AudioLibraryPrefab;
	public GameObject AnimationLibraryPrefab;
	public GameObject EntityLibraryPrefab;

    public float Gravity;

    void Awake(){
		GameManager.SetState(GameState.LoadLibraries);
    }
}
