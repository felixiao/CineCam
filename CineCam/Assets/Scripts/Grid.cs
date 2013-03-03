using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public float width = 5.0f;
    public float height = 5.0f;
	public Color color = Color.white;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDrawGizmos()
	{
//	    Vector3 pos = Camera.current.transform.position;
	  	
//	    for (float y = pos.y - 8.0f; y < pos.y + 8.0f; y+= height)
//	    {
//	        Gizmos.DrawLine(new Vector3(-10.0f, Mathf.Floor(y/height) * height, 0.0f),
//	                        new Vector3(10.0f, Mathf.Floor(y/height) * height, 0.0f));
//			Gizmos.DrawSphere(new Vector3(0f, Mathf.Floor(y/height) * height, 0.0f),1);
//	    }
	  
//	    for (float x = pos.x - 12.0f; x < pos.x + 12.0f; x+= width)
//	    {
//	        Gizmos.DrawLine(new Vector3(Mathf.Floor(x/width) * width, -10.0f, 0.0f),
//	                        new Vector3(Mathf.Floor(x/width) * width, 10.0f, 0.0f));
//			Gizmos.DrawSphere(new Vector3(Mathf.Floor(x/width) * width, 0.0f, 0.0f),1);
//	    }
	}
}
