using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class CineCamIdiom:MonoBehaviour {
	public int ID;
	public CineCamShot[] shotSet;
	public List<CineCamRule> rules=new List<CineCamRule>();
	public int shotIDMax=1;
	public int PlayingShot=0;
	void Start(){
		//rules.Add(new CineCamRule());
		shotSet=transform.GetComponentsInChildren<CineCamShot>();
		Debug.Log("shotcount:"+shotSet.Length);
		Debug.Log("rules:"+rules.Count);
		shotSet[PlayingShot].OnStart();
	}
	void Update(){
		foreach(CineCamRule ru in rules){
			if(ru.ShotFrom==shotSet[PlayingShot])
				ru.CheckCondition();
		}
	}
	public void OnPlay(){
		shotSet[PlayingShot].OnStart();
	}
	public void AddShot(CineCamShot shot){
		shot.ID=shotIDMax++;
		//shotSet.Add(shot);
		shot.transform.parent=transform;
	}
}