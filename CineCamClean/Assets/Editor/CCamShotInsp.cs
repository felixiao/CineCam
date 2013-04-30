using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CanEditMultipleObjects]
[CustomEditor(typeof(CineCamShot))]
public class CCamShotInsp: Editor {
	
	public override void OnInspectorGUI () {
		CineCamShot ccshot=(CineCamShot)target;
		ccshot.mType=(CineCamShot.MotionType)EditorGUILayout.EnumPopup("Motion Type",ccshot.mType);
		ccshot.fType=(CineCamShot.FrameType)EditorGUILayout.EnumPopup("Frame Type",ccshot.fType);
		ccshot.lType=(CineCamShot.LookAtType)EditorGUILayout.EnumPopup("Target Type",ccshot.lType);
		switch(ccshot.mType){
		case CineCamShot.MotionType.Fixed:
			ccshot.FixedPos=EditorGUILayout.Vector3Field("Position",ccshot.FixedPos);
			if(GUILayout.Button("Apply Current Camera Pos"))
				ccshot.FixedPos=ccshot.transform.position;
			break;
		case CineCamShot.MotionType.Follow:
			ccshot.AttachTo=(Transform)EditorGUILayout.ObjectField("Attached to",ccshot.AttachTo,typeof(Transform));
			ccshot.offsetPos=EditorGUILayout.Vector3Field("Offset Pos",ccshot.offsetPos);
			break;
		case CineCamShot.MotionType.PresetPath:
			break;
		}
		switch(ccshot.lType){
			case CineCamShot.LookAtType.Fixed:
			ccshot.AimAtPos=EditorGUILayout.Vector3Field("Target",ccshot.AimAtPos);
			break;
			case CineCamShot.LookAtType.Follow:
			ccshot.AimAt=(Transform)EditorGUILayout.ObjectField("Target",ccshot.AimAt,typeof(Transform));
			break;
			case CineCamShot.LookAtType.PresetRotation:
			break;
		}
		
		if(GUILayout.Button("Set Camera")){
			Camera.SetupCurrent(ccshot.camera);
			switch(ccshot.mType){
			case CineCamShot.MotionType.Fixed:
				ccshot.transform.position=ccshot.FixedPos;
				break;
			case CineCamShot.MotionType.Follow:
				ccshot.transform.position=ccshot.AttachTo.position+ccshot.AttachTo.forward*ccshot.offsetPos.z
					+ccshot.AttachTo.right*ccshot.offsetPos.x+ccshot.AttachTo.up*ccshot.offsetPos.y;
				break;
			}
		}
		//EditorGUIUtility.RenderGameViewCameras(new Rect(0.5f,0.5f,1f,1f),true,false);
    }
}