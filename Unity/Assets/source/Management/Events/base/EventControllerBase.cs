using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class EventControllerBase {

	protected readonly EventContainerBase container;

	public event Action OnInitialize;
	public event Action OnPreload;
	public event Action OnDestroy;

	protected Dictionary<string , int> _eventOccurances = new Dictionary<string , int>();

	protected EventControllerBase(EventContainerBase p_container){
		container = p_container;
	}

	public virtual void Awake(){
		RegisterEvent("OnInitialize");
		RegisterEvent("OnPreLoad");
		RegisterEvent("OnDestroy");

		LogEventOccurance("OnInitialize");
		if(OnInitialize != null) OnInitialize.Invoke();
	}
	public virtual void Start(){
		LogEventOccurance("OnPreLoad");
		if(OnPreload != null) OnPreload.Invoke();
	}
	public virtual void Update(){
	}
	public virtual void Destroy(){
		LogEventOccurance("OnDestroy");
		if(OnDestroy != null) OnDestroy.Invoke();
	}

	protected void RegisterEvent(string p_eventName){
		_eventOccurances.Add(p_eventName , 0);
	}

	protected void LogEventOccurance(string p_eventName){
		if(!_eventOccurances.ContainsKey(p_eventName)){
			Debug.LogError(string.Format("Event '{0}' is not registered", p_eventName));
			return;
		}
		_eventOccurances[p_eventName]++;
	}
}
