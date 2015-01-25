using UnityEngine;
using System.Collections;

[System.Serializable]
public class PrefabLibraryItem{
	public string 		PrefabName;
	public GameObject 	Prefab;
}

public class PrefabLibrary : MonoBehaviour {

	public static bool Initiated = false;
	
	[SerializeField] private string LibraryName;

	public PrefabLibraryItem[] prefabLibraryItems;

	public static void Init(GameObject prefabLibraryPrefab){
		if(Initiated) return;
		if(prefabLibraryPrefab == null){
			Debug.Log("[PrefabLibrary] -> Init : Initiate failed because prefabLibraryPrefab is null");
			return;
		}
		Initiated = true;
		GameObject prefabLibrary = GameObject.Find("_PrefabLibrary");
		if (prefabLibrary != null) Destroy(prefabLibrary);
		
		GameObject newPrefabLibrary = Instantiate(prefabLibraryPrefab) as GameObject;
		newPrefabLibrary.name = "_PrefabLibrary";
	}

	void Start(){
		Debug.Log("[PrefabLibrary] (" + LibraryName + ") Filling Library");
		foreach(PrefabLibraryItem item in prefabLibraryItems){
			PrefabFactory.Addentity(item.PrefabName , item.Prefab);
		}
		GameManager.SetState(GameState.Menu);
	}

}
