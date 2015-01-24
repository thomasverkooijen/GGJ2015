using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioLibraryItem{
	
	public	string      		eventName;
	public	float       		volumeMin 			=	1;
	public	float       		volumeMax 			=	1;
	public	float       		pitchMin 			=	1;
	public	float       		pitchMax			=	1;
	public	float       		rangeMin			=	0;
	public	float       		rangeMax			=	500;
	public	AudioClip[] 		clips;
	public	AudioRolloffMode	rollOfMode 			= AudioRolloffMode.Linear;	
}

public class AudioLibrary : MonoBehaviour{

	public static bool Initiated = false;
	
	[SerializeField] private string LibraryName;

	public AudioLibraryItem[] audioLibraryItems;
	
	public static void Init(GameObject audioLibraryPrefab){
		if(Initiated) return;
		if(audioLibraryPrefab == null){
			Debug.Log("[AudioLibrary] -> Init : Initiate failed because audioLibraryPrefab is null");
			return;
		}
		Initiated = true;
		GameObject audioLibrary = GameObject.Find("_AudioLibrary");
		if (audioLibrary != null) Destroy(audioLibrary);

		GameObject newAudioLibrary = Instantiate(audioLibraryPrefab) as GameObject;
		newAudioLibrary.name = "_AudioLibrary";
	}
	
	// --------------------------------------------------------------------------------------------
	// Fills the audio library with all the audio clips
	// --------------------------------------------------------------------------------------------
	void Start(){
		Debug.Log("[AudioLibrary] (" + LibraryName + ") Filling Library");
		foreach(AudioLibraryItem item in audioLibraryItems){
		    AudioManager.AddEvent(item.eventName , item.volumeMin , item.volumeMax , item.pitchMin , item.pitchMax , item.rangeMin , item.rangeMax , item.rollOfMode);
			AudioManager.AddClips( item.eventName, item.clips );
		}
	}
	
	// --------------------------------------------------------------------------------------------
	// Don't destroy this gameObject when Loading a new scene
	// --------------------------------------------------------------------------------------------
	public void Awake(){
		DontDestroyOnLoad( gameObject );	
	}
	
}