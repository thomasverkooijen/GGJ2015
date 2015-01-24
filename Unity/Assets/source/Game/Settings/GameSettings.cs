using UnityEngine;
using System.Collections;

public class GameSettings : Singleton<GameSettings>
{
    //public static GameSettings Instance;
    public GameObject AudioLibraryPrefab;
    public GameObject GuiStateLibraryPrefab;
    public GameObject GuiTweenLibrary;

    public float Gravity;

    void Awake()
    {
        AudioLibrary.Init(AudioLibraryPrefab);
    }

    public float JumpSpeedBase = 15.0f;
}
