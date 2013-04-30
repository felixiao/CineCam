using UnityEngine;
using System.Collections;
using UnityEditor;
public class CCamShotMenu: EditorWindow {
	string myString = "CineCam";
	GameObject camSubject;
	GameObject camTarget;
	Camera camObject;
	public enum PType{
		CloseUp,Medium,Full,Wide
	}
	PType staticFlagMask= 0;

	void OnGUI(){
		GUILayout.Label ("Create a New Shot", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField ("Shot Name", myString);
		camSubject=(GameObject)EditorGUILayout.ObjectField("Subject",camSubject,typeof(GameObject));
		camTarget=(GameObject)EditorGUILayout.ObjectField("Target",camTarget,typeof(GameObject));
		camObject=(Camera)EditorGUILayout.ObjectField("Camera",camObject,typeof(Camera));
		
		staticFlagMask = (PType)EditorGUILayout.EnumMaskField ( "Static Flags", staticFlagMask );
		if(GUILayout.Button("Create")){
			GameObject man=(GameObject)Instantiate(Resources.Load("Prefab/Manager"));
			man.name="CineCam Manager";
		}
		//groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		//	myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		//	myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		//EditorGUILayout.EndToggleGroup ();
	}
	[MenuItem("CineCam/Add New Shot")]
	public static void OpenWindowShot(){
		EditorWindow.GetWindow(typeof(CCamShotMenu)).Show();
	}
}
