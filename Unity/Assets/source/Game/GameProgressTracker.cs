using UnityEngine;
using System.Collections;

public class GameProgressTracker : MonoBehaviour {

    public static int FinishedObjects = 0;

	// Use this for initialization
	void Start () {
        GameManager.SetState(GameState.InGame);
	}

    public static void ObjectFinished(GameObject g)
    {
        GameManager.RemoveEntity(g);
        FinishedObjects++;
        GameManager.SetState(GameState.Finish);
    }
}
