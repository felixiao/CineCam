using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// CineCam shot.
/// 
/// </summary>
public class CineCamShot{
	public enum PType{
		CloseUp,Medium,Full,Wide
	}
	public GameObject Subject;//i.e. player
	public GameObject Target;//i.e. enemy
	public CCamMovement ccMove;//movement
	public CCamPlacement ccPlace;//position
	public bool isCurrent;// is this the current cam
	public Camera cam;//the camera itself
	
	//constructer
	public CineCamShot(){
		this.Subject=new GameObject();
		this.Target=new GameObject();
		this.cam=new Camera();
		this.ccMove=new CCamMovement();
		this.ccPlace=new CCamPlacement(CCamPlacement.Preset.OverShoudler);
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="CineCamShot"/> class.
	/// </summary>
	/// <param name='move'>
	/// Move.
	/// </param>
	/// <param name='place'>
	/// Place.
	/// </param>
	/// <param name='sub'>
	/// Subject of the camera. Indicates where the camera is attaching to.
	/// </param>
	/// <param name='tar'>
	/// Target of the camera. Indicates where the camera is looking at.
	/// </param>
	public CineCamShot(CCamMovement move,CCamPlacement place,GameObject sub,GameObject tar){
		this.cam=new Camera();
		this.Subject=sub;
		this.Target=tar;
		this.ccMove=move;
		this.ccPlace=place;
	}
	public void Init(){
		Debug.Log("sub: "+Subject.name+", tar: "+Target.name);
		if(Subject==null)
			Debug.Log("Sub=null");
		if(Target==null)
			Debug.Log("Tar=null");
		if(ccPlace==null)
			Debug.Log("ccPlace=null");
		if(cam==null){
			Debug.Log("cam=null");
			this.cam=Camera.main;
		}
		cam.transform.position=Subject.transform.position+
			Subject.transform.right*-0.2f+Subject.transform.up*0.8f+Subject.transform.forward*-0.3f;
		Debug.Log("cam pos: "+cam.transform.position);
		cam.transform.LookAt(Target.transform.position);
	}
	public Camera SetCurrentCamera(){
		Init();
		isCurrent=true;
		return cam;
	}
	public void OnStart(){
	}
	public void OnPlay(){
	}
	public void OnStop(){
	}
}


public class CCamMovement{
	public Transform transform;
	public enum Preset{
		Fixed,Zoom,Tracking,
	}
	public void Init(){
	}
}

public class CCamPlacement{
	public enum Preset{
		OverShoudler,CloseShot,FOV,OverHead,Fixed,Relative
	}
	public Preset preset;
	public Transform trans;
	
	//constructer
	public CCamPlacement(Preset preset){
		this.preset=preset;
		if(preset==Preset.Fixed)
			throw new Exception("You must assign a transform when you apply Fixed Cam.");
	}
	//constructer for fixed cam
	public CCamPlacement(Preset preset,Transform trans){
		this.preset=preset;
		this.trans=trans;
	}
	public Vector3 InitPosition(GameObject sub,GameObject tar){
		if(sub==null)
			Console.WriteLine("Sub=null");
		if(tar==null)
			Console.WriteLine("Tar=null");
		Vector3 position=sub.transform.position-sub.transform.right+new Vector3(0,1,0)-sub.transform.forward;
		
		switch(preset){
		case Preset.Fixed:
			break;
		case Preset.CloseShot:
			break;
		case Preset.FOV:
			break;
		case Preset.OverHead:
			break;
		case Preset.OverShoudler:
			
			break;
		}
		return position;
	}
	public void Update(GameObject target){
		switch(preset){
		case Preset.Fixed:
			return;
		case Preset.CloseShot:
			break;
		case Preset.FOV:
			
			break;
		case Preset.OverHead:
			break;
		case Preset.OverShoudler:
			break;
		}
	}
}
