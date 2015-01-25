using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    void Awake()
    {
        GameManager.SetState(GameState.Menu);
    }

    public void TwoPlayerMatch()
    {
        LoadLevel(2);
    }

    public void ThreePlayerMatch()
    {
        LoadLevel(3);
    }

    public void FourPlayerMatch()
    {
        LoadLevel(4);
    }

    public void LoadLevel(int _numberOfPlayers)
    {
        GameSettings.Instance.NumberOfPlayers = _numberOfPlayers;
        Application.LoadLevel("Level4");
    }
}
