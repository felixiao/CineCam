using UnityEngine;
using System.Collections;

public class CineCamRule{
	#region Enum
	public enum TransitionType{
		JumpCut,Fade
	}
	public enum ConditionType{
		KeyEvent,MouseEvent,TimeOut,HitEvent,GameEvent,ShotEvent
	}
	public enum MouseButton{
		Left,Right,Middle
	}
	#endregion
	
	#region properties
	public CineCamShot ShotFrom;
	public CineCamShot ShotTo;
	public TransitionType ShotTrans;//transistion between shots
	
	public ConditionType ConType;
	public KeyCode ConKeyCode;
	public MouseButton ConMouseBtn;
	public float ConTimeOut;
	public object ConditionConten;
	float TimePassed=0f;
	#endregion
	
	public CineCamRule(){
		 
	}
	
	public CineCamShot CheckCondition(){
		switch(ConType){
		case ConditionType.KeyEvent:
			if(Input.anyKeyDown&&Input.GetKeyDown(ConKeyCode)){
				Camera.SetupCurrent(ShotTo.camera);
				ShotTo.OnStart();
				return ShotTo;
			}
			break;
		case ConditionType.MouseEvent:
			if(Input.GetMouseButtonUp((int)ConMouseBtn)){
				Camera.SetupCurrent(ShotTo.camera);
				ShotTo.OnStart();
				return ShotTo;
			}
			break;
		case ConditionType.TimeOut:
			TimePassed+=Time.deltaTime;
			if(TimePassed>=ConTimeOut){
				Camera.SetupCurrent(ShotTo.camera);
				ShotTo.OnStart();
				return ShotTo;
			}
			break;
		case ConditionType.ShotEvent:
			if(!ShotFrom.isPlaying){
				Camera.SetupCurrent(ShotTo.camera);
				ShotTo.OnStart();
				return ShotTo;
			}
			break;
		case ConditionType.GameEvent:
			break;
		case ConditionType.HitEvent:
			break;
		}
		return ShotFrom;
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
