using UnityEngine;
using System.Collections;

public class CineCamRule {
	public CCamTransistion ccTrans;//transistion between shots
	public CineCamShot shotA;
	public CineCamShot shotB;
	public bool Condition=false;
	//public delegate Action; //using delegate to perform actions when meet the condition
	public CineCamRule(CCamTransistion ccTrans,CineCamShot shota,CineCamShot shotb){
		this.ccTrans=ccTrans;
		this.shotA=shota;
		this.shotB=shotb;
	}
	public void Action(){
		if(Condition&&Camera.current==shotA.cam){
			Camera.SetupCurrent(ccTrans.Translate(shotA,shotB));
			Condition=false;
		}
	}
//	public bool CheckCondition(object val, Type t, string con, object compare){
//		switch(con){
//		case "<":
//			if((t)val<(t)compare)
//				return true;
//			break;
//		case "<=":
//			if((t)val<=(t)compare)
//				return true;
//			break;
//		case "==":
//			if((t)val==(t)compare)
//				return true;
//			break;
//			
//		case ">=":
//			if((t)val>=(t)compare)
//				return true;
//			break;
//			
//		case ">":
//			if((t)val>(t)compare)
//				return true;
//			break;
//		default:
//			if((t)val==(t)compare)
//				return true;
//			break;
//		}
//		return false;
//	}
}
