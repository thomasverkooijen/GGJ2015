using UnityEngine;
using System.Collections;
using UnityEditor;

public class AudioObject : MonoBehaviour {

	private int 		_loopCount = 0;
	public int 			loopCount{ get{return _loopCount;} set{_loopCount = value;} }

	public bool			isPlaying{
		get{
			if(_audioSource == null) return false;
			if(loopCount > 0) return true;
			if(_audioSource.isPlaying) return true;
			return false;
		}
	}

	private AudioSource _audioSource;
	public AudioSource 	audioSource{get{return _audioSource;}}

	void Awake(){
		_audioSource = gameObject.AddComponent<AudioSource>();
		_audioSource.playOnAwake = false;
	}

	void Update(){
		if(_audioSource.isPlaying == false){
			if(loopCount > 0){
				loopCount --;
				_audioSource.Play();
			}
		}
	}
}
