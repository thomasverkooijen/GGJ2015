using UnityEngine;
using System.Collections;

public class GameSettings : Singleton<GameSettings>
{
    public GameObject AudioLibraryPrefab;
	public GameObject AnimationLibraryPrefab;
	public GameObject EntityLibraryPrefab;

    public float Gravity;
    public int NumberOfPlayers = 2;
    public int NumberOfAI = 10;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
		GameManager.SetState(GameState.LoadLibraries);
    }
}