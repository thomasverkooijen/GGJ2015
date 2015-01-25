using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioDictionary{
	public AudioClip[] 			audioClips;
	public float				volumeMin;
	public float				volumeMax;
	public float				pitchMin;
	public float				pitchMax;
	public float				rangeMin;
	public float				rangeMax;
	public AudioRolloffMode 	rollOfMode;
	public float				previousClip = -1;
}

public static class AudioManager {
	private static GameObject 											_audioManagerTarget;
	private static readonly Dictionary<string, AudioDictionary> 		_audioDictionary = new Dictionary<string, AudioDictionary>();
	private static readonly List<AudioObject>							_audioObjectList = new List<AudioObject>();

	private static AudioDictionary GetAudioDictionary(string p_eventName){
		if(!_audioDictionary.ContainsKey(p_eventName)) return null;
		AudioDictionary audioDictionary = _audioDictionary[p_eventName];
		return audioDictionary;
	}

	public static void Clear(){
		_audioObjectList.Clear();
	}

	public static AudioClip GetAudioClip(string p_eventName){
		AudioDictionary audioDictionary = GetAudioDictionary(p_eventName);
		if(audioDictionary == null){
			Debug.Log("[AudioManager] -> Play : Library item with name(" + p_eventName + ") cant be found");
			return null;
		}
		if(audioDictionary.audioClips == null){
			Debug.Log("[AudioManager] -> Play : Library item(" + p_eventName + ") has no audioClips property");
			return null;
		}
		if(audioDictionary.audioClips.Length <= 0){
			Debug.Log("[AudioManager] -> Play : Library item(" + p_eventName + ") has no audio clips");
			return null;
		}
		int randomClipIndex	= Random.Range(0,audioDictionary.audioClips.Length);
		return audioDictionary.audioClips[randomClipIndex];
	}

	public static AudioSource Play(GameObject p_target , bool p_isChildOfTarget, string p_eventName){
		return Play(p_target , p_isChildOfTarget , p_eventName , false , 0);
	}

	public static AudioSource Play(GameObject p_target , bool p_isChildOfTarget, string p_eventName , bool p_isLoop , int p_loopTimes){

		AudioObject 		audioObject 	= FindUsableAudioObject();
		SetAudioObjectTarget(audioObject , p_target , p_isChildOfTarget);
		AudioDictionary 	audioDictionary = GetAudioDictionary(p_eventName);
		_audioObjectList.Add(audioObject);
		if(audioDictionary == null){
			Debug.Log("Cant find audioLibrary Event with name ("+p_eventName+")");
			return null;
		}
		if(audioDictionary.audioClips == null){
			Debug.Log("Audioclips in Event with name ("+p_eventName+") are null");
			return null;
		}
		int 				randomClipIndex	= Random.Range(0,audioDictionary.audioClips.Length);
		float 				randomVolume	= Random.Range(audioDictionary.volumeMin , audioDictionary.volumeMax);
		float 				randomPitch		= Random.Range(audioDictionary.pitchMin , audioDictionary.pitchMax);
		float 				rangeMin		= audioDictionary.rangeMin;
		float 				rangeMax		= audioDictionary.rangeMax;
		AudioRolloffMode	rollOfMode		= audioDictionary.rollOfMode;
		AudioClip 			clip			= audioDictionary.audioClips[randomClipIndex];

		if(clip == null){
			Debug.Log("[AudioManager] -> Play : AudioClip in "+ p_eventName +" null");
			return null;
		}

		if(p_isLoop)	audioObject.loopCount = p_loopTimes;
		else 		audioObject.loopCount = 0;

		audioObject.audioSource.clip 			= clip;
		audioObject.audioSource.volume			= randomVolume;
		audioObject.audioSource.pitch			= randomPitch;
		audioObject.audioSource.minDistance 	= rangeMin;
		audioObject.audioSource.maxDistance		= rangeMax;
		audioObject.audioSource.rolloffMode		= rollOfMode;
		audioObject.audioSource.Play();
		return audioObject.audioSource;
	}

	private static AudioObject FindUsableAudioObject(){
		foreach(AudioObject audioObject in _audioObjectList){
			if(audioObject.isPlaying) continue;
			return audioObject;
		}
		return CreateAudioObject();
	}

	private static AudioObject CreateAudioObject(){
		GameObject container = new GameObject("AudioObject");
		AudioObject audioObject = container.AddComponent<AudioObject>();
		return audioObject;
	}

	private static void SetAudioObjectTarget(AudioObject p_audioObject , GameObject p_target , bool p_isChildOfTarget){
		if(p_audioObject == null){
			Debug.Log("[AudioManager]->SetAudioObjectTarget : audioObject = null");
			return;
		}
		if(p_target == null){
			p_audioObject.transform.parent	= null;
			p_audioObject.transform.position 	= Vector3.zero;
		}
		else{
			if(p_isChildOfTarget){
				p_audioObject.transform.parent 		= p_target.transform;
				p_audioObject.transform.localPosition = Vector3.zero;
			}
			else{
				p_audioObject.transform.parent 	= null;
				p_audioObject.transform.position 	= p_target.transform.position;
			}
		}
	}

	public static void AddEvent( string p_eventName, float p_volumeMin, float p_volumeMax, float p_pitchMin, float p_pitchMax, float p_rangeMin, float p_rangeMax , AudioRolloffMode p_rollOfMode){
		if(_audioDictionary.ContainsKey(p_eventName)) return;
		AudioDictionary audioDictionary = new AudioDictionary();
		audioDictionary.volumeMin 		= p_volumeMin;
		audioDictionary.volumeMax 		= p_volumeMax;
		audioDictionary.pitchMin  		= p_pitchMin;
		audioDictionary.pitchMax  		= p_pitchMax;
		audioDictionary.rangeMin  		= p_rangeMin;
		audioDictionary.rangeMax  		= p_rangeMax;
		audioDictionary.previousClip	= -1;
		audioDictionary.rollOfMode		= p_rollOfMode;
		_audioDictionary[p_eventName] 	= audioDictionary;
	}
	
	public static void AddClips(string p_eventName, AudioClip[] p_audioClips){
		if(p_audioClips == null)							return;
		if(p_audioClips.Length == 0)						return;
		if(!_audioDictionary.ContainsKey(p_eventName))	return;
		AudioDictionary audioDictionary	= _audioDictionary[p_eventName];
		audioDictionary.audioClips 		= p_audioClips;
	}

}