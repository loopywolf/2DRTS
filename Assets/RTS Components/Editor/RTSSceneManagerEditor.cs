using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RTSSceneManager))]
public class RTSSceneManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RTSSceneManager rtsSceneManager = (RTSSceneManager)target;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("Generate Tile Map"))
        {
            rtsSceneManager.Generate();
        }
        if (GUILayout.Button("Clear Tile Map"))
        {
            rtsSceneManager.ClearTileMap();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("Check Grid Exist"))
        {
            rtsSceneManager.CheckGridExist();
        }
        if(GUILayout.Button("Set Cell Neighbors"))
        {
            rtsSceneManager.SetCellNeighbors();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        DrawDefaultInspector();

    }
}
