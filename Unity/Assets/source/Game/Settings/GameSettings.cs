using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	public static GameSettings Instance;
	public GameObject	AudioLibraryPrefab;
	public GameObject	GuiStateLibraryPrefab;
	public GameObject	GuiTweenLibrary;

	public float		Gravity;
	
	void Awake(){
		GameSettings.Instance = this;
		AudioLibrary.Init(AudioLibraryPrefab);
	}
}
