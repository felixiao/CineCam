using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class CineCamIdiom {
	public string name;
	public int id;
	public List<CineCamShot> shotSet;
	public List<CineCamRule> rules;
	
	public CineCamIdiom(string name,int id){
		this.rules=new List<CineCamRule>();
		this.shotSet=new List<CineCamShot>();
		this.name=name;
		this.id=id;
	}
	public void Update(){
		foreach(CineCamRule r in rules){
			r.Action();
		}
	}
	
}

public class CCamTransistion{
	public enum Transision{
		FadeOut,FadeIn,FadeOutIn,JumpCut
	}
	public float fadeTime=1.0f;
	public Transision transi;
	public CCamTransistion(Transision tran){
		this.transi=tran;
	}
	public Camera Translate(CineCamShot shotA,CineCamShot shotB){
		shotA.isCurrent=false;
		switch(transi){
		case Transision.FadeIn:
			break;
		case Transision.FadeOut:
			break;
		case Transision.FadeOutIn:
			break;
		case Transision.JumpCut:
			return shotB.SetCurrentCamera();
		}
		return shotB.SetCurrentCamera();
	}
	
}