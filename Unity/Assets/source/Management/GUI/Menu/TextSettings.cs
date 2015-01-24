using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextSettings{

	Font			_font;
	int				_fontSize;
	Color			_textColor;
	TextAnchor		_textAnchor;
	FontStyle		_fontStyle;


	public Font 		Font		{get{return _font;}}
	public int 			FontSize	{get{return _fontSize;}}
	public Color 		TextColor	{get{return _textColor;}}
	public TextAnchor 	TextAnchor	{get{return _textAnchor;}}
	public FontStyle 	FontStyle	{get{return _fontStyle;}}


	private readonly static Dictionary<string , TextSettings> _textSettingsDictionary = new Dictionary<string, TextSettings>();

	public static TextSettings Retrieve(string p_name){
		if(!_textSettingsDictionary.ContainsKey(p_name)){
			Debug.Log("Cant find TextSettings with name : " + p_name);
			return null;
		}
		return _textSettingsDictionary[p_name];
	}

	public static TextSettings Create(string p_name , Font p_font , int p_fontSize , Color p_textColor){
		TextSettings s = new TextSettings(p_font , p_fontSize , p_textColor , TextAnchor.MiddleLeft , FontStyle.Normal);
		_textSettingsDictionary[p_name] = s;
		return s;
	}
	public static TextSettings Create(string p_name , Font p_font , int p_fontSize , Color p_textColor , TextAnchor p_textAnchor){
		TextSettings s = new TextSettings(p_font , p_fontSize , p_textColor , p_textAnchor , FontStyle.Normal);
		_textSettingsDictionary[p_name] = s;
		return s;
	}
	public static TextSettings Create(string p_name , Font p_font , int p_fontSize , Color p_textColor , TextAnchor p_textAnchor , FontStyle p_fontStyle){
		TextSettings s = new TextSettings(p_font , p_fontSize , p_textColor , p_textAnchor , p_fontStyle);
		_textSettingsDictionary[p_name] = s;
		return s;
	}
	
	public TextSettings(Font p_font , int p_fontSize , Color p_textColor , TextAnchor p_textAnchor , FontStyle p_fontStyle){
		_font			= p_font;
		_fontSize		= p_fontSize;
		_textColor		= p_textColor;
		_textAnchor		= p_textAnchor;
		_fontStyle		= p_fontStyle;
	}
}
