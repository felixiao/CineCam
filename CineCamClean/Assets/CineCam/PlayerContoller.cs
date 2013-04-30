using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {
	// The speed when walking
	public float walkSpeed = 2.0f;
	// after trotAfterSeconds of walking we trot with trotSpeed
	public float trotSpeed = 4.0f;
	// when pressing "Fire3" button (cmd) we start running
	public float runSpeed = 6.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Forward vector relative to the camera along the x-z plane	
		//var forward = camForward;//cameraTransform.TransformDirection(Vector3.forward);
		//forward.y = 0;
		//forward = forward.normalized;
	
		// Right vector relative to the camera
		// Always orthogonal to the forward vector
		//var right = Vector3(forward.z, 0, -forward.x);
		
		var v = Input.GetAxisRaw("Vertical");
		var h = Input.GetAxisRaw("Horizontal");
		// Target direction relative to the camera
		var targetDirection = h * transform.right + v * transform.forward;
		Rotate(h);
		Move(v);
	}
	
	void Move(float v){
		if(v>=0){
			transform.position+=transform.forward*v*Time.deltaTime*walkSpeed;
		}
		else{
			transform.position+=transform.forward*v*Time.deltaTime*walkSpeed;
		}
	}
	void Rotate(float h){
		transform.RotateAround(Vector3.up,h*Time.deltaTime*trotSpeed);
	}
}
