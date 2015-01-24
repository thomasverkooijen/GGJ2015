using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityFactory : Singleton<EntityFactory> {

    public Vector3 SpawnPosition = new Vector3(0,10.0f,0);

	public void PopulateListOfPlayers (ref List<GameObject> listOfPlayers, GameObject PlayerObject, int _numberOfPlayers) {
        for (int i = 0; i < _numberOfPlayers; i++)
        {
            GameObject newPlayer = Instantiate(PlayerObject, SpawnPosition, Quaternion.identity) as GameObject;
            PlayerInputController inputController = newPlayer.GetComponent<PlayerInputController>();
            inputController._playerIndex = i;
            listOfPlayers.Add(newPlayer);
        }
        AddRandomVelocity(listOfPlayers);
	}

    public void PopulateListOfAI(ref List<GameObject> listOfAI, GameObject AIObject, int _numberOfAI)
    {
        for (int i = 0; i < _numberOfAI; i++)
        {
            GameObject newPlayer = Instantiate(AIObject, SpawnPosition, Quaternion.identity) as GameObject;
            listOfAI.Add(newPlayer);
        }
        AddRandomVelocity(listOfAI);
    }

    private void AddRandomVelocity(List<GameObject> targets)
    {
        foreach(GameObject go in targets)
        {
            MovementController mc = go.GetComponent<MovementController>();
            if (mc != null)
            {
                mc.Move(Random.value*10.0f, Random.value);
            }
        }
    }
}
