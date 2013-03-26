using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

[CustomEditor (typeof(Grid))]
public class GridEditor : Editor
{
	Grid grid;
	static List<Transform> points=new List<Transform>();
	static string PATH=Environment.CurrentDirectory+"//Save//savePATH.txt";
	
	public void OnEnable()
	{
	    grid = (Grid)target;
	    SceneView.onSceneGUIDelegate += GridUpdate;
	}
	 public void OnDisable()
	{
	    SceneView.onSceneGUIDelegate -= GridUpdate;
	}
	
	void GridUpdate(SceneView sceneview)
	{
		Event e = Event.current;
		GameObject obj;
	    if (e.isKey&&(e.character=='w'||e.character=='W'))
	    {
			
			System.Console.WriteLine("a");
			Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
			RaycastHit rayhit=new RaycastHit();
			obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			if(Physics.Raycast(r, out rayhit)){
				obj.transform.position = rayhit.point;
			}
			obj.tag="WayPoints";
			obj.name="WayPoint";
			points.Add(obj.transform);
            //obj.transform.position = r.GetPoint(15.0f);
			
	    }
		if (e.isKey&&(e.character=='C'||e.character=='c'))
	    {
			Camera cam=(Camera)UnityEngine.Object.Instantiate(Camera.current);
			cam.tag="MainCamera";
			cam.name="cam";
		}
	}
	public override void OnInspectorGUI(){
		GUILayout.BeginHorizontal();
	    GUILayout.Label(" Grid Width ");
	    //grid.width = EditorGUILayout.FloatField(grid.width, GUILayout.Width(50));
	    GUILayout.EndHorizontal();
	  
	    GUILayout.BeginHorizontal();
	    GUILayout.Label(" Grid Height ");
	    //grid.height = EditorGUILayout.FloatField(grid.height, GUILayout.Width(50));
	    GUILayout.EndHorizontal();
	  
		if (GUILayout.Button("Open Grid Window", GUILayout.Width(255)))
	    {
	       GridWindow window = (GridWindow) EditorWindow.GetWindow(typeof(GridWindow));
	       window.Init();
	    }
	    SceneView.RepaintAll();
	}
	
	static void CreatePath(){
		if(!Directory.Exists(Environment.CurrentDirectory+"//Save"))
			Directory.CreateDirectory(Environment.CurrentDirectory+"//Save");
		File.Create(PATH);
	}
	[MenuItem("CineCam/Save/Get Path")]
	static void ReadPath(){
		if(!File.Exists(PATH))
			return;
		else{
			StreamReader sr=new StreamReader(PATH);
			while(!sr.EndOfStream){
				string line=sr.ReadLine();
				//string camera=line.Split(':')[0];
				string trans=line.Split(':')[1];
				string[] tran=trans.Split(';');
				foreach(string s in tran){
					System.Console.WriteLine(s);
				}
			}
			sr.Close();
		}
	}
	[MenuItem("CineCam/Save/Save Path")]
	static void SavePath(){
		if(!File.Exists(PATH))
			CreatePath();
		
		StreamWriter sw=new StreamWriter(PATH,false,System.Text.Encoding.UTF8);
		string line="cam01:";
		foreach(Transform tr in points){
			System.Console.WriteLine(tr.position.ToString());
			line+=tr.position.ToString()+";";
		}
		sw.WriteLine(line);
		sw.Flush();
		sw.Close();
		
	}
}
