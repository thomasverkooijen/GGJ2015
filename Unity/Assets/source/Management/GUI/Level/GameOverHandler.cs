using UnityEngine;
using System.Collections;

public class GameOverHandler : MonoBehaviour {

    public GameObject InGameScreen, GameOverScreenM06Won, GameOverScreenSentientBotsWon;

    public enum VictoryState { GameInProgress, M06Won, SentientBotsWon };
    public VictoryState CurrentVictoryState = VictoryState.GameInProgress;

	// Use this for initialization
	void Start () {
        Init();
	}

    public void Init()
    {
        InGameScreen.SetActive(true);
        GameOverScreenM06Won.gameObject.SetActive(false);
        GameOverScreenSentientBotsWon.gameObject.SetActive(false);
    }

    public void GameOver(VictoryState newVictoryState)
    {
        CurrentVictoryState = newVictoryState;
        InGameScreen.SetActive(false);
        if (CurrentVictoryState==VictoryState.M06Won)
        {
            GameOverScreenM06Won.gameObject.SetActive(true);
        }
        else
        {
            GameOverScreenSentientBotsWon.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        GameManager.SetState(GameState.InGame);
        Init();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
