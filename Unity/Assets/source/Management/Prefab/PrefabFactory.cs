using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabFactory : MonoBehaviour {

	private static readonly Dictionary<string, GameObject> _prefabDictionary = new Dictionary<string, GameObject>();

	public static void Addentity(string p_name , GameObject p_prefab){
		if(_prefabDictionary.ContainsKey(p_name)){
			Debug.Log("Prefab with name("+p_name+") already exists");
			return;
		}
		_prefabDictionary[p_name] = p_prefab;
	}

	public static GameObject Build(GameObject p_target , string p_prefabName , Vector3 p_worldPos){
		if(!_prefabDictionary.ContainsKey(p_prefabName)){
			Debug.Log("[PrefabFactory] : Entity ("+p_prefabName+") was not found");
			return null;
		}
		GameObject g = GameObject.Instantiate(_prefabDictionary[p_prefabName]) as GameObject;
		g.name = p_prefabName;
		g.transform.position = p_worldPos;
		if(p_target != null){
			g.transform.parent = p_target.transform;
		}
		return g;
	}

}
