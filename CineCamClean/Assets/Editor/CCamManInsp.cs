using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

[CanEditMultipleObjects]
[CustomEditor(typeof(CineCamMan))]
public class CCamManInsp : Editor {
	string idiomName="New Idiom";
	public override void OnInspectorGUI (){
		
		CineCamMan ccManager=(CineCamMan)target;
		EditorGUILayout.LabelField("Idioms Count: "+ccManager.idioms.Count);
		idiomName=EditorGUILayout.TextField("Idiom Name",idiomName);
		if(GUILayout.Button("Add new Idioms")){
			GameObject idiom=(GameObject)Instantiate(Resources.Load("Prefab/Idiom"));
			idiom.name=idiomName;
			idiom.transform.parent=ccManager.transform;
			ccManager.idioms.Add(idiom.GetComponent<CineCamIdiom>());
		}
		
	}
}
