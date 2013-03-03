using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System;
public class CameraControl : MonoBehaviour {
	public List<Camera> cams;
	public List<Transform> points;
	int countMove=0;
	Vector3 targetPoint;
	Vector3 moveDirection;
	Quaternion wayRotation;
	public float speed=2.0f;
	public float damping =5.0f;
	bool moving=false;
	int i=0;
	
	// Use this for initialization
	void Start () {
		UnityEngine.Object[] gb=Camera.FindObjectsOfType(typeof(Camera));
		foreach(UnityEngine.Object g in gb){
			if(((Camera)g).tag=="MainCamera")
				cams.Add((Camera)g);
		}
		GameObject[] wayP=GameObject.FindGameObjectsWithTag("WayPoints");
		foreach(GameObject way in wayP){
			points.Add(way.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V)&&cams!=null&&cams.Count>0){
			i++;
			if(i>=cams.Count){
				i=0;
			}
			cams.ForEach(delegate(Camera c){
				c.enabled=false;
			});
			cams[i].enabled=true;
		}
		
		if (Input.GetKeyDown(KeyCode.M)){
			moving=!moving;
		}
		if(moving&&countMove<points.Count){
			targetPoint=points[countMove].position;
			moveDirection=targetPoint-Camera.current.transform.position;
			if(moveDirection.magnitude<0.2){
				countMove++;
			}
			else{
				Camera.current.transform.position+=moveDirection.normalized*speed*Time.deltaTime;
				wayRotation=Quaternion.LookRotation(targetPoint-Camera.current.transform.position);
				Camera.current.transform.rotation=Quaternion.Slerp(transform.rotation,wayRotation,Time.deltaTime*damping);
				
			}
			if(countMove>=points.Count){
				countMove=0;
				moving=false;
				
			}
		}
		else{
			countMove=0;
		}
	}
	
}
