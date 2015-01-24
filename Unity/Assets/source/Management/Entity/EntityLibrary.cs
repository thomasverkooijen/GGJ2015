using UnityEngine;
using System.Collections;

[System.Serializable]
public class EntityLibraryItem{
	public string 		EntityName;
	public GameObject 	Entity;
}

public class EntityLibrary : MonoBehaviour {

	public static bool Initiated = false;
	
	[SerializeField] private string LibraryName;

	public EntityLibraryItem[] entityLibraryItems;

	public static void Init(GameObject entityLibraryPrefab){
		if(Initiated) return;
		if(entityLibraryPrefab == null){
			Debug.Log("[EntityLibrary] -> Init : Initiate failed because entityLibraryPrefab is null");
			return;
		}
		Initiated = true;
		GameObject entityLibrary = GameObject.Find("_EntityLibrary");
		if (entityLibrary != null) Destroy(entityLibrary);
		
		GameObject newEntityLibrary = Instantiate(entityLibraryPrefab) as GameObject;
		newEntityLibrary.name = "_EntityLibrary";
	}

	void Start(){
		Debug.Log("[EntityLibrary] (" + LibraryName + ") Filling Library");
		foreach(EntityLibraryItem item in entityLibraryItems){
			EntityFactory.Addentity(item.EntityName , item.Entity);
		}
	}

}
