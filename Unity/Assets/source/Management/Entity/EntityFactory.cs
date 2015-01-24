using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityFactory : MonoBehaviour {

	private static readonly Dictionary<string, GameObject> _entityDictionary = new Dictionary<string, GameObject>();

	public static void Addentity(string p_name , GameObject p_entity){
		if(_entityDictionary.ContainsKey(p_name)){
			Debug.Log("entity with name("+p_name+") already exists");
			return;
		}
		_entityDictionary[p_name] = p_entity;
	}

	public static GameObject Build(GameObject p_target , string p_entityName , Vector3 p_worldPos){
		if(!_entityDictionary.ContainsKey(p_entityName)){
			Debug.Log("[EntityFactory] : Entity ("+p_entityName+") was not found");
			return null;
		}
		GameObject g = GameObject.Instantiate(_entityDictionary[p_entityName]) as GameObject;
		g.name = p_entityName;
		g.transform.position = p_worldPos;
		if(p_target == null){
			g.transform.parent = p_target.transform;
		}
		return g;
	}

}
