using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	LoadLibraries,
	Menu,
	InGame,
	Finish
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
			AudioManager.Clear();
            ActiveEntities = new List<GameObject>();
            CreateAIPlayers();
			AudioManager.Play(null , false , "MenuTheme" , true , -1);
			AudioManager.Play(null , false , "SoundScape" , true , -1);
			Debug.Log("Load Menu");
			break;
		case GameState.InGame:
			//Load LEVEL scene
			AudioManager.Clear();
            ActiveEntities = new List<GameObject>();
			CreatePlayers();
			CreateAIPlayers();
			AudioManager.Play(null , false , "GameTheme" , true , -1);
			AudioManager.Play(null , false , "SoundScape" , true , -1);
			Debug.Log("Load Ingame");
			break;
		case GameState.Finish:
            foreach (GameObject entity in ActiveEntities)
            {
                RemoveEntity(entity);
            }
            ActiveEntities = new List<GameObject>();
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
            if (i == 0)
            {
                g.GetComponent<ControllerSelector>().SwitchController(true);
            }
            else
            {
                g.GetComponent<ControllerSelector>().SwitchController(false);
            }
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
        GameObject.Destroy(entity);
    }
}
