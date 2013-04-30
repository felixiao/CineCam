using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/* 
 * 
 * 
 * 
 * 
 */ 

public class CineCamMan : MonoBehaviour {
	public List<CineCamIdiom> idioms=new List<CineCamIdiom>();
	int idiomIDMax=1;
	public int PlayingShot=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(idioms!=null&&idioms.Count>0&&PlayingShot<idioms.Count&&idioms[PlayingShot]!=null)
			idioms[PlayingShot].OnPlay();
		
	}
	void OnGUI(){
	}
	public void AddIdiom(CineCamIdiom idiom){
		idiom.ID=idiomIDMax++;
		idioms.Add(idiom);
		idiom.transform.parent=transform;
	}
}
