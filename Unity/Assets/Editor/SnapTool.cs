using UnityEngine;
using UnityEditor;

public class SnapTool : EditorWindow {

	private static SnapTool _instance;

	private int _snapSize = 1;

	[MenuItem("LevelDesign/SnapTool")]
	static void Init(){
		_instance = (SnapTool)EditorWindow.GetWindow(typeof(SnapTool));
	}

	void OnGUI(){
		_snapSize = EditorGUILayout.IntField("Size:" , _snapSize);
	}

	void Update(){

		GameObject[] activeGameObjects = Selection.gameObjects;
		foreach(GameObject g in activeGameObjects){
			float xPos = Mathf.Floor(g.transform.position.x/_snapSize)*_snapSize;
			float yPos = Mathf.Floor(g.transform.position.y/_snapSize)*_snapSize;
			float zPos = 0;
			g.transform.position = new Vector3(xPos , yPos , zPos);
			float rotation = Mathf.Floor(g.transform.eulerAngles.z/90)*90;
			g.transform.eulerAngles = new Vector3(0,0,rotation);
		}

	}

}
