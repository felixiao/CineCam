using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CineCamManager : MonoBehaviour {
	CineCamIdiom cineIdiom;
	public List<string> dialog;
	int diaIndex=0;
	public GameObject npca;
	public GameObject npcb;
	// Use this for initialization
	void Start () {
		cineIdiom=new CineCamIdiom("Dialog",0);
		
		CCamPlacement ccPlaceA=new CCamPlacement(CCamPlacement.Preset.OverShoudler);
		CCamMovement ccMoveA=new CCamMovement();
		CineCamShot shotA=new CineCamShot(ccMoveA,ccPlaceA,npca,npcb);
		
		CCamPlacement ccPlaceB=new CCamPlacement(CCamPlacement.Preset.OverShoudler);
		CCamMovement ccMoveB=new CCamMovement();
		CineCamShot shotB=new CineCamShot(ccMoveB,ccPlaceB,npcb,npca);
		
		CineCamRule rule1=new CineCamRule(new CCamTransistion(CCamTransistion.Transision.JumpCut),shotA,shotB);
		CineCamRule rule2=new CineCamRule(new CCamTransistion(CCamTransistion.Transision.JumpCut),shotB,shotA);
		
		cineIdiom.shotSet.Add(shotA);
		cineIdiom.shotSet.Add(shotB);
		
		cineIdiom.rules.Add(rule1);
		cineIdiom.rules.Add(rule2);
		
		dialog.Add("Hello.");
		dialog.Add("Hi.");
		dialog.Add("How are you?");
		dialog.Add("I am good. How are you?");
		dialog.Add("I am ok. Let's get some food?");
		dialog.Add("Great! I am hungry.");
		Camera.SetupCurrent(cineIdiom.shotSet[0].SetCurrentCamera());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			diaIndex++;
			if(diaIndex>=dialog.Count)
				diaIndex=0;
			foreach(CineCamRule rule in cineIdiom.rules)
				if(rule.shotA.isCurrent)
					rule.Condition=true;
		}
		cineIdiom.Update();
	}
	void OnGUI(){
		GUI.TextArea(new Rect(10, 10, 200, 100), dialog[diaIndex], 200);
	}
}
