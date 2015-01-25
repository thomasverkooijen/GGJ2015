using UnityEngine;
using System.Collections;

public class GameProgressTracker : MonoBehaviour
{

    public static int FinishedObjects = 0;
    public static GameOverHandler GameOverHandlerInstance;

    // Use this for initialization
    void Start()
    {
        GameManager.SetState(GameState.InGame);
    }

    public static void ObjectFinished(GameObject g)
    {
        FinishedObjects++;
        GameManager.SetState(GameState.Finish);

        GameOverHandler.VictoryState newVictoryState = GameOverHandler.VictoryState.GameInProgress;
        if (g.GetComponent<PlayerController>() != null)
        {
            newVictoryState = GameOverHandler.VictoryState.SentientBotsWon;
        }
        else
        {
            newVictoryState = GameOverHandler.VictoryState.M06Won;
        }
        GameObject.Find("LevelUI").GetComponent<GameOverHandler>().GameOver(newVictoryState);
    }
}
