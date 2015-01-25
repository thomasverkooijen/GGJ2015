using UnityEngine;
using System.Collections;

public class Preloader : MonoBehaviour {

    public void Start()
    {
        //Pre-game initialization code can be placed here.
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(.1f);
        Application.LoadLevel("Menu");
    }
}