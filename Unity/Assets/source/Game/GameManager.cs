using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	LoadLibraries,
	Menu,
	InGame,
	Finsh
}

public static class GameManager{

	private static GameState _currentState;
	public static GameState CurrenState{get{return _currentState;}}

    public static List<GameObject> ActiveEntities;

	public static void SetState(GameState p_state){
		Debug.Log("[GameManager] GameState set to " + p_state);
		switch(p_state){
		case GameState.LoadLibraries:
			AudioLibrary.Init(GameSettings.Instance.AudioLibraryPrefab);
			AnimationLibrary.Init(GameSettings.Instance.AnimationLibraryPrefab);
			PrefabLibrary.Init(GameSettings.Instance.EntityLibraryPrefab);
			break;
		case GameState.Menu:
			//Load MENU scene
            ActiveEntities = new List<GameObject>();
            CreateAIPlayers();
			break;
		case GameState.InGame:
			//Load LEVEL scene
            ActiveEntities = new List<GameObject>();
			CreatePlayers();
			CreateAIPlayers();
			break;
		case GameState.Finsh:
			//go to ENDGAME scene
			break;
		}
	}

	private static void LoadMenu(){
	}

	private static void CreatePlayers(){
		for(int i = 0 ; i < GameSettings.Instance.NumberOfPlayers ; i++){
			GameObject g = PrefabFactory.Build(null , "Player" , new Vector2(0,10));
			Player p = g.GetComponent<Player>();
			if(p != null) p.EntityID = i;
            ActiveEntities.Add(g);
		}
	}

	private static void CreateAIPlayers(){
		for(int i = 0 ; i < GameSettings.Instance.NumberOfAI ; i++){
			GameObject g = PrefabFactory.Build(null , "AIPlayer" , new Vector2(Random.Range(-10,10),10+Random.Range(0,10)));
			AIplayer p = g.GetComponent<AIplayer>();
			if(p != null) p.EntityID = -1;
            ActiveEntities.Add(g);
		}
	}

    public static void RemoveEntity(GameObject entity)
    {
        ActiveEntities.Remove(entity);
    }
}
