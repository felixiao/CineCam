using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
/// <summary>
/// CineCam shot.
/// 
/// </summary>

public class CineCamShot:MonoBehaviour{

	#region General properties
	public enum FrameType{
		CloseUp,Medium,Full,Wide
	}
	public enum MotionType{
		Follow,Fixed,PresetPath,Free
	}
	public enum LookAtType{
		Follow,Fixed,PresetRotation,Free
	}
	public FrameType fType;
	public MotionType mType;
	public LookAtType lType;
	public Transform AimAt;//i.e. enemy
	public Vector3 AimAtPos;
	public Vector3 offsetPos=new Vector3(0,0,0);
	public int ID;
	#endregion
	#region Fixed properties
	public Vector3 FixedPos;
	
	#endregion
	#region Follow properties
	public Transform AttachTo;//i.e. player
	#endregion
	#region PresetPath
	
	#endregion
	
	public bool isCurrent;// is this the current cam
	
	public bool isPlaying=false;
	//constructer
	void Start(){
		
	}
	void Update(){
		if(isPlaying)
			OnPlay();
	}
/*
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
*/
	public void OnStart(){
		isPlaying=true;
		Camera.SetupCurrent(transform.camera);
		Debug.Log(ID+"OnStart");
	}
	public void OnPlay(){
		SetCamPos();
		SetCamRotation();
		GameObject[] go=GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject g in go){
			g.SendMessage("setCamForward",camera,SendMessageOptions.DontRequireReceiver);
		}
	}
	public void OnStop(){
		isPlaying=false;
	}
	public void SetCamPos(){
		switch(mType){
		case MotionType.Fixed:
			//do noting while the camera placement is fixed.
			break;
		case MotionType.Follow:
			//make the camera followed by the attached object.
			if(lType==LookAtType.Follow)
				transform.position=AttachTo.position+AttachTo.forward*offsetPos.z+AttachTo.right*offsetPos.x+AttachTo.up*offsetPos.y;
			else
				transform.position=AttachTo.position+offsetPos;
			break;
		case MotionType.PresetPath:
			//make the camera followed by the preset path.
			break;
		case MotionType.Free:
			//make the camera controled by user input.
			break;
		}
	}
	
	public void SetCamRotation(){
		switch(lType){
		case LookAtType.Fixed:
			//do noting while the camera always look at same direction.
			return;
		case LookAtType.Follow:
			//keep the camera looking at the target object.
			if(mType==MotionType.Follow)
				transform.localRotation=AimAt.localRotation;
			else	
				transform.LookAt(AimAt.position);
			break;
		case LookAtType.PresetRotation:
			//make the camera looking at preset directions.
			transform.LookAt(AimAtPos);
			break;
		case LookAtType.Free:
			//control the camera's direction by user input.
			break;
		}
	}

//	[ExecuteInEditMode]
//	void OnDestroy(){
//		transform.parent.GetComponent<CineCamIdiom>().RemoveShot(ID);
//	    Debug.Log ("Disabled or Destroyed");
//	}
}