using UnityEngine;
using System.Collections;

public class AIPlayerView : MonoBehaviour {
	
	private GameObject _playerHead;
	private GameObject _playerLegs;
	
	public GameObject PlayerHead{get{return _playerHead;}}
	public GameObject PlayerLegs{get{return _playerLegs;}}
	
	void Awake(){
		if(_playerHead == null){
			_playerHead = new GameObject("PlayerHead");
			_playerHead.transform.parent = transform;
			_playerHead.transform.localPosition = Vector3.zero;
		}
		if(_playerLegs == null){
			_playerLegs = new GameObject("PlayerLegs");
			_playerLegs.transform.parent = transform;
			_playerLegs.transform.localPosition = Vector3.zero;
		}
	}
	
}
