using UnityEngine;
using System.Collections;
using UnityEditor;
public class CCamManMenu : EditorWindow {
	string strName = "Manager";

	void OnGUI(){
		GUILayout.Label ("Create a New CineCam Manager", EditorStyles.boldLabel);
		strName = EditorGUILayout.TextField ("Manager Name", strName);
		
		if(GUILayout.Button("Create")){
			GameObject man=(GameObject)Instantiate(Resources.Load("Prefab/Manager"));
			GameObject idi=(GameObject)Instantiate(Resources.Load("Prefab/Idiom"));
			GameObject sho=(GameObject)Instantiate(Resources.Load("Prefab/Shot"));
			man.name=strName;
			CineCamIdiom idiom=idi.GetComponent<CineCamIdiom>();
			CineCamShot shot=sho.GetComponent<CineCamShot>();
			idiom.AddShot(shot);
			man.GetComponent<CineCamMan>().AddIdiom(idiom);
		}
	}
	[MenuItem("CineCam/Create CCManager")]
	public static void OpenWindowManager(){
		EditorWindow.GetWindow(typeof(CCamManMenu)).Show();
	}
}
