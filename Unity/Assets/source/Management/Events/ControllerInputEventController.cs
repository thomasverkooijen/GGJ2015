using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;

public enum ControllerButton{
	A,
	B,
	X,
	Y,
	Start,
	Back,
	DPadLeft,
	DPadRight,
	DPadUp,
	DPadDown,
	LeftStick,
	RightStick,
	LeftTrigger,
	RightTrigger,
	LeftShoulder,
	RightShoulder
}

public enum StickType{
	LeftX,
	LeftY,
	RightX,
	RightY
}

public class ControllerInputEventController : EventControllerBase {

	[SerializeField] private float _deadZone = 0.3f;
	private GamePadState[] _states;
	private GamePadState[] _previousStates;

	public delegate void ButtonEventDelegate(ControllerButton p_controllerButton , int p_playerIndex);
	public delegate void StickEventDelegate(StickType p_stickType , float p_speed , int p_playerIndex);

	public event ButtonEventDelegate 	OnButtonPressed;
	public event ButtonEventDelegate 	OnButtonReleased;
	public event StickEventDelegate		OnStickActive;

	public ControllerInputEventController(EventContainerBase p_container) : base(p_container){
		_states 		= new GamePadState[4];
		_previousStates	= new GamePadState[4];
	}

	public override void Awake(){
		base.Awake();
	}

	public override void Start(){
		base.Start();
	}

	// Update is called once per frame
	public override void Update(){
		base.Update();

		for(int i = 0 ; i < 4 ; i ++){
			PlayerIndex playerIndex = (PlayerIndex)i;
			_previousStates[i] = _states[i];
			_states[i] = GamePad.GetState(playerIndex);
			if(_states[i].IsConnected && _previousStates[i].IsConnected){


				if(_previousStates[i].Buttons.A == ButtonState.Released && _states[i].Buttons.A == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.A , i);
				}
				else if(_previousStates[i].Buttons.A == ButtonState.Pressed && _states[i].Buttons.A == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.A , i);
				}
				if(_previousStates[i].Buttons.B == ButtonState.Released && _states[i].Buttons.B == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.B , i);
				}
				else if(_previousStates[i].Buttons.B == ButtonState.Pressed && _states[i].Buttons.B == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.B , i);
				}
				if(_previousStates[i].Buttons.X == ButtonState.Released && _states[i].Buttons.X == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.X , i);
				}
				else if(_previousStates[i].Buttons.X == ButtonState.Pressed && _states[i].Buttons.X == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.X , i);
				}
				if(_previousStates[i].Buttons.Y == ButtonState.Released && _states[i].Buttons.Y == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.Y , i);
				}
				else if(_previousStates[i].Buttons.Y == ButtonState.Pressed && _states[i].Buttons.Y == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.Y , i);
				}


				if(_previousStates[i].Buttons.Back == ButtonState.Released && _states[i].Buttons.Back == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.Back , i);
				}
				else if(_previousStates[i].Buttons.Back == ButtonState.Pressed && _states[i].Buttons.Back == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.Back , i);
				}
				if(_previousStates[i].Buttons.Start == ButtonState.Released && _states[i].Buttons.Start == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.Start , i);
				}
				else if(_previousStates[i].Buttons.Start == ButtonState.Pressed && _states[i].Buttons.Start == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.Start , i);
				}


				if(_previousStates[i].Buttons.LeftShoulder == ButtonState.Released && _states[i].Buttons.LeftShoulder == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.LeftShoulder , i);
				}
				else if(_previousStates[i].Buttons.LeftShoulder == ButtonState.Pressed && _states[i].Buttons.LeftShoulder == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.LeftShoulder , i);
				}
				if(_previousStates[i].Buttons.RightShoulder == ButtonState.Released && _states[i].Buttons.RightShoulder == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.RightShoulder , i);
				}
				else if(_previousStates[i].Buttons.RightShoulder == ButtonState.Pressed && _states[i].Buttons.RightShoulder == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.RightShoulder , i);
				}


				if(_previousStates[i].Buttons.LeftStick == ButtonState.Released && _states[i].Buttons.LeftStick == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.LeftStick , i);
				}
				else if(_previousStates[i].Buttons.LeftStick == ButtonState.Pressed && _states[i].Buttons.LeftStick == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.LeftStick , i);
				}
				if(_previousStates[i].Buttons.RightStick == ButtonState.Released && _states[i].Buttons.RightStick == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.RightStick , i);
				}
				else if(_previousStates[i].Buttons.RightStick == ButtonState.Pressed && _states[i].Buttons.RightStick == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.RightStick , i);
				}


				if(_previousStates[i].DPad.Left == ButtonState.Released && _states[i].DPad.Left == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.DPadLeft , i);
				}
				else if(_previousStates[i].DPad.Left == ButtonState.Pressed && _states[i].DPad.Left == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.DPadLeft , i);
				}
				if(_previousStates[i].DPad.Right == ButtonState.Released && _states[i].DPad.Right == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.DPadRight , i);
				}
				else if(_previousStates[i].DPad.Right == ButtonState.Pressed && _states[i].DPad.Right == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.DPadRight , i);
				}
				if(_previousStates[i].DPad.Up == ButtonState.Released && _states[i].DPad.Up == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.DPadUp , i);
				}
				else if(_previousStates[i].DPad.Up == ButtonState.Pressed && _states[i].DPad.Up == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.DPadUp , i);
				}
				if(_previousStates[i].DPad.Down == ButtonState.Released && _states[i].DPad.Down == ButtonState.Pressed){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.DPadDown , i);
				}
				else if(_previousStates[i].DPad.Down == ButtonState.Pressed && _states[i].DPad.Down == ButtonState.Released){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.DPadDown , i);
				}


				if(_previousStates[i].Triggers.Left < 1 && _states[i].Triggers.Left == 1){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.LeftTrigger , i);
				}
				else if(_previousStates[i].Triggers.Left == 1 && _states[i].Triggers.Left < 1){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.LeftTrigger , i);
				}
				if(_previousStates[i].Triggers.Right < 1 && _states[i].Triggers.Right == 1){
					if(OnButtonPressed != null) OnButtonPressed.Invoke(ControllerButton.RightTrigger , i);
				}
				else if(_previousStates[i].Triggers.Right == 1 && _states[i].Triggers.Right < 1){
					if(OnButtonReleased != null) OnButtonReleased.Invoke(ControllerButton.RightTrigger , i);
				}

				if(Mathf.Abs(_states[i].ThumbSticks.Left.X) > _deadZone){
					if(OnStickActive != null) OnStickActive.Invoke(StickType.LeftX , _states[i].ThumbSticks.Left.X , i);
				}
				if(Mathf.Abs(_states[i].ThumbSticks.Left.Y) > _deadZone){
					if(OnStickActive != null) OnStickActive.Invoke(StickType.LeftY , _states[i].ThumbSticks.Left.Y , i);
				}
				if(Mathf.Abs(_states[i].ThumbSticks.Right.X) > _deadZone){
					if(OnStickActive != null) OnStickActive.Invoke(StickType.RightX , _states[i].ThumbSticks.Right.X , i);
				}
				if(Mathf.Abs(_states[i].ThumbSticks.Right.Y) > _deadZone){
					if(OnStickActive != null) OnStickActive.Invoke(StickType.RightY , _states[i].ThumbSticks.Right.Y , i);
				}
			}
		}

	}

	public override void Destroy(){
		base.Destroy();
	}
}
