using UnityEngine;
using UnityEditor;
using System.Collections;
  
public class GridWindow : EditorWindow
{
	Grid grid;
    public void Init()
    {
		grid = (Grid)FindObjectOfType(typeof(Grid));
    }
	void OnGUI()
    {
        grid.color = EditorGUILayout.ColorField(grid.color, GUILayout.Width(200));
		//string path=EditorUtility.SaveFilePanelInProject("save the camera Path","savePath.txt","txt", "Please enter a file name to save the path to");
    }
	
	
}

