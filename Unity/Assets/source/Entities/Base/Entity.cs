using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour, IEntity 
{
	protected	string	_name;
	protected	Vector2	_pos;
	protected 	Vector2	_size;
	protected 	int		_entityID;

	public		int 	EntityID{get{return _entityID;} set{_entityID = value;}}
	public		string	Name{get{return _name;} set{_name = value;}}
	public		Vector2	Pos{get{return transform.position;}}
	public		Vector2	Size{get{return _size;} set{_size = value;}}
}
