using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class EventContainerBase : MonoBehaviour {

	private 			bool 						_awakeCalled 		= false;
	private readonly 	List<EventControllerBase>	_eventControllers	= new List<EventControllerBase>();

	protected void AddController(EventControllerBase p_eventController){
		if(_awakeCalled)
			throw new Exception("You're only allowed to add new controllers before calling base.awake");
		_eventControllers.Add(p_eventController);
	}

	protected T GetController<T>() where T : EventControllerBase{
		foreach(EventControllerBase eventController in _eventControllers){
			if(eventController is T){
				return (T) eventController;
			}
		}
		throw new Exception(string.Format("Error: Can't find event controller of type {0}, please add it using AddController!", typeof (T)));
	}

	protected virtual void Awake(){
		_awakeCalled = true;
		foreach(EventControllerBase eventController in _eventControllers){
			eventController.Awake();
		}
	}

	protected virtual void Start(){
		foreach(EventControllerBase eventController in _eventControllers){
			eventController.Start();
		}
	}

	protected virtual void Update(){
		foreach(EventControllerBase eventController in _eventControllers){
			eventController.Update();
		}
	}

	protected virtual void OnDestroy(){
		foreach(EventControllerBase eventController in _eventControllers){
			eventController.Destroy();
		}
	}
}
