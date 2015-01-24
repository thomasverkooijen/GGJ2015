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
}
