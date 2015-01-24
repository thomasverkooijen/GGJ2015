using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityManager : Singleton<EntityManager>
{

    public List<GameObject> Players;
    public List<GameObject> AI;
    public List<GameObject> AllEntities;

    public GameObject PlayerPrefab;
    public GameObject AIPrefab;

    public int NumberOfPlayers = 4;
    public int NumberOfAI = 10;

    public int NumberOfPlayersFinished = 0;
    public int NumberOfAIFinished = 0;

    // Use this for initialization
    void Start()
    {
        Players = new List<GameObject>();
        EntityFactory.Instance.PopulateListOfPlayers(ref Players, PlayerPrefab, NumberOfPlayers);
        Players[0].GetComponent<PlayerInputController>().ToggleOverseerMode(true);
        AI = new List<GameObject>();
		EntityFactory.Instance.PopulateListOfAI(ref AI, AIPrefab, NumberOfAI);
        AllEntities = new List<GameObject>(Players);
        foreach (var ai in AI)
        {
            AllEntities.Add(ai);
        }
    }

    public float FindCenterOfActiveEntities()
    {
        float leftBoundX = float.PositiveInfinity;
        float rightBoundX = float.NegativeInfinity;
        for(int i = 0; i < AllEntities.Count; i++)
        {
            PlayerInputController playerInputController = AllEntities[i].GetComponent<PlayerInputController>();
            if (playerInputController != null)
            {
                if (playerInputController.IsOverseer)
                {
                    continue;
                }
            }
            if (AllEntities[i].transform.position.x <= leftBoundX)
            {
                leftBoundX = AllEntities[i].transform.position.x;
            }
            if (AllEntities[i].transform.position.x >= rightBoundX)
            {
                rightBoundX = AllEntities[i].transform.position.x;
            }
        }
        float center = (leftBoundX + rightBoundX) / 2;
        return center;
    }

    public void EntityFinishes(GameObject entity)
    {
        if (Players.Contains(entity))
        {
            NumberOfPlayersFinished++;
        }
        if (AI.Contains(entity))
        {
            NumberOfAIFinished++;
        }
        RemoveEntity(entity);
    }

    /// <summary>
    /// Use this to remove entities, both when finishing and when destroyed by environments and such
    /// </summary>
    /// <param name="entity">The entity to remove (either a player or AI object)</param>
    public void RemoveEntity(GameObject entity)
    {
        if(Players.Contains(entity))
        {
            Players.Remove(entity);
        }
        if (AI.Contains(entity))
        {
            AI.Remove(entity);
        }
        if (AllEntities.Contains(entity))
        {
            AllEntities.Remove(entity);
        }
        Destroy(entity);
    }

    public void OnGUI()
    {
        //TODO: Replace when properly starting on GUI
        GUI.color = Color.black;
        GUI.Box(new Rect(Screen.width - 150, 0, 150, 50), "");
        GUI.color = Color.white;
        GUI.Label(new Rect(Screen.width - 125, 0, 100, 25), "Players finished:");
        GUI.Label(new Rect(Screen.width - 25, 0, 25, 25), NumberOfPlayersFinished.ToString());
        GUI.Label(new Rect(Screen.width - 125, 30, 100, 25), "AI finished:");
        GUI.Label(new Rect(Screen.width - 25, 30, 25, 25), NumberOfAIFinished.ToString());
    }
}
