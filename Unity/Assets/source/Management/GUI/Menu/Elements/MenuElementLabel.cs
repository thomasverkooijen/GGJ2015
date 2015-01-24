using UnityEngine;
using System.Collections;

public class MenuElementLabel{
	public bool					Enabled = true;
	public bool 				Animated = false;
	public Rect 				Rect;
	public string 				Text;
	public Font					Font{get{return Style.font;} set{Style.font = value;}}
	public int					FontSize{get{return Style.fontSize;} set{Style.fontSize = value;}}
	public TextAnchor 			TextAnchor{get{return Style.alignment;} set{Style.alignment = value;}}
	public Color				Color{get{return Style.normal.textColor;} set{Style.normal.textColor = value;}}
	public GUIStyle				Style;

	public float				Width{get{return Style.CalcSize(new GUIContent(Text)).x;}}
	public float				Height{get{return Style.CalcSize(new GUIContent(Text)).y;}}

	public void MakeShort(float p_maxWidth , int p_dots){
		if(p_maxWidth < 0) p_maxWidth = 0;
		for(int i = 0 ; i < p_dots ; i++){
			Text += ".";
		}
		bool resized = false;
		while(Width > p_maxWidth){
			resized = true;
			int l = Text.Length-(p_dots+1);
			if(l < 0) l = 0;
			Text = Text.Substring(0, l);
			if(l > 0){
				for(int i = 0 ; i < p_dots ; i++){
					Text += ".";
				}
			}
		}
		if(!resized) Text = Text.Substring(0, Text.Length - (p_dots));
	}
}
