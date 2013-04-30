using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

[CanEditMultipleObjects]
[CustomEditor(typeof(CineCamIdiom))]
public class CCamIdiomInsp : Editor {
	CineCamRule.ConditionType cType;
	CineCamRule.TransitionType tType;
	CineCamRule.MouseButton mType;
	KeyCode ConKeyCode;
	CineCamShot ShotFrom;
	CineCamShot ShotTo;
	
	float ConTimeOut;
	object ConditionConten;
	
	public override void OnInspectorGUI () {
		CineCamIdiom ccidiom=(CineCamIdiom)target;
		List<CineCamRule> rules=ccidiom.rules;
		EditorGUILayout.LabelField("Shots Count: "+ccidiom.transform.childCount);
		EditorGUILayout.LabelField("Rules Count: "+ccidiom.rules.Count);
		
		if(GUILayout.Button("Add New Shot")){
			GameObject shot=(GameObject)Instantiate(Resources.Load("Prefab/Shot"));
			shot.name="New Shot";
			ccidiom.AddShot(shot.GetComponent<CineCamShot>());
//			shot.transform.parent=ccidiom.transform;
//			shot.GetComponent<CineCamShot>().ID=ccidiom.shotIDMax++;
//			ccidiom.shotSet.Add(shot.GetComponent<CineCamShot>());
		}
		
		EditorGUILayout.Separator();
		ShotFrom=(CineCamShot)EditorGUILayout.ObjectField("From Shot",ShotFrom,typeof(CineCamShot));
		ShotTo=(CineCamShot)EditorGUILayout.ObjectField("To Shot",ShotTo,typeof(CineCamShot));
		cType=(CineCamRule.ConditionType)EditorGUILayout.EnumPopup("Condition",cType);
		tType=(CineCamRule.TransitionType)EditorGUILayout.EnumPopup("Transition",tType);
		switch(cType){
			case CineCamRule.ConditionType.KeyEvent:
				ConKeyCode=(KeyCode)EditorGUILayout.EnumPopup("Key",ConKeyCode);
				break;
			case CineCamRule.ConditionType.MouseEvent:
				mType=(CineCamRule.MouseButton)EditorGUILayout.EnumPopup("MouseButton",mType);
				break;
			case CineCamRule.ConditionType.TimeOut:
				ConTimeOut=EditorGUILayout.FloatField("TimeOut",ConTimeOut);
				break;
			case CineCamRule.ConditionType.ShotEvent:
				break;
			case CineCamRule.ConditionType.GameEvent:
				break;
			case CineCamRule.ConditionType.HitEvent:
				break;
		}
//		for(int i=ccidiom.rules.Count-1;i>=0;i--){
//			ccidiom.rules[i]=(CineCamRule)EditorGUILayout.ObjectField("CineCam Rule",ccidiom.rules[i],typeof(CineCamRule));
//		}
		
		if(GUILayout.Button("Add New Rule")){
			CineCamRule rule=new CineCamRule();
			rule.ConType=cType;
			rule.ShotFrom=ShotFrom;
			rule.ShotTo=ShotTo;
			rule.ShotTrans=tType;
			
			rule.ConKeyCode=ConKeyCode;
			rule.ConMouseBtn=mType;
			rule.ConTimeOut=ConTimeOut;
			rule.ConditionConten=ConditionConten;
			ccidiom.rules.Add(rule);
		}
	}
}
