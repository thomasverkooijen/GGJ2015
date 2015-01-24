using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MenuElement{

	private readonly	Dictionary<string , MenuElementTexture> _textureDictionary = new Dictionary<string, MenuElementTexture>();
	private readonly	Dictionary<string , MenuElementLabel> _labelDictionary = new Dictionary<string, MenuElementLabel>();

	private				Vector2						_pos;
	private				string						_name;

	public MenuElement(string p_name , Vector2 p_pos){
		_name	=	p_name;
		_pos	=	p_pos;
	}

	public MenuElementLabel AddLabel(string p_name , Rect p_rect , string p_text , TextSettings p_textSettings){
		MenuElementLabel l = new MenuElementLabel();
		l.Rect				= p_rect;
		l.Text				= p_text;
		l.Style				= new GUIStyle();
		l.Style.wordWrap	= false;
		l.Style.fontStyle	= p_textSettings.FontStyle;
		l.Font				= p_textSettings.Font;
		l.FontSize			= p_textSettings.FontSize;
		l.Color				= p_textSettings.TextColor;
		l.TextAnchor		= p_textSettings.TextAnchor;
		if(_labelDictionary.ContainsKey(p_name)){
			Debug.Log("Label with name (" + p_name + ") already exists");
			return null;
		}
		_labelDictionary[p_name] = l;
		return l;
	}

	public MenuElementLabel GetLabel(string p_name){
		if(!_labelDictionary.ContainsKey(p_name)){
			Debug.Log("Label with name (" + p_name + ") doesnt exist");
			return null;
		}
		return _labelDictionary[p_name];
	}
	public List<MenuElementLabel> GetAllLabels(){
		return _labelDictionary.Values.ToList();
	}
	public void RemoveLabel(string p_name){
		if(!_labelDictionary.ContainsKey(p_name)){
			Debug.Log("Label with name (" + p_name + ") doesnt exist");
			return;
		}
		_labelDictionary.Remove(p_name);
	}


	public MenuElementTexture AddTexture(string p_name , Rect p_rect , Texture p_texture , Color p_color){
		MenuElementTexture m = new MenuElementTexture();
		m.Rect		= p_rect;
		m.Texture	= p_texture;
		m.Color		= p_color;
		if(_textureDictionary.ContainsKey(p_name)){
			Debug.Log("Texture with name (" + p_name + ") already exists");
			return null;
		}
		_textureDictionary[p_name] = m;
		return m;
	}

	public MenuElementTexture GetTexture(string p_name){
		if(!_textureDictionary.ContainsKey(p_name)){
			Debug.Log("Texture with name (" + p_name + ") doesnt exist");
			return null;
		}
		return _textureDictionary[p_name];
	}
	public List<MenuElementTexture> GetAllTextures(){
		return _textureDictionary.Values.ToList();
	}
	public void RemoveTexture(string p_name){
		if(!_textureDictionary.ContainsKey(p_name)){
			Debug.Log("Texture with name (" + p_name + ") doesnt exist");
			return;
		}
		_textureDictionary.Remove(p_name);
	}

	public void Draw(){
		DrawTextures();
		DrawLabels();
	}

	private void DrawTextures(){
		foreach(MenuElementTexture texture in _textureDictionary.Values){
			GUI.color = texture.Color;
			GUI.DrawTexture(new Rect(_pos.x+texture.Rect.x , _pos.y+texture.Rect.y , texture.Rect.width , texture.Rect.height) , texture.Texture);
		}
	}
	
	private void DrawLabels(){
		foreach(MenuElementLabel label in _labelDictionary.Values){
			GUI.color = label.Color;
			GUI.skin.label.font = label.Font;
			GUI.skin.label.fontSize = label.FontSize;
			GUI.skin.label.alignment = label.TextAnchor;
			GUI.Label(new Rect(_pos.x+label.Rect.x , _pos.y+label.Rect.y , label.Rect.width , label.Rect.height) , label.Text);
		}
	}
}
