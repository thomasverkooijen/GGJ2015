using UnityEngine;
using System.Collections;

public class LoadLibrary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.SetState(GameState.LoadLibraries);
	}
}
