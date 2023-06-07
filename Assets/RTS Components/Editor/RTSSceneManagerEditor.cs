using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RTSSceneManager))]
public class RTSSceneManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RTSSceneManager rtsSceneManager = (RTSSceneManager)target;
        if (GUILayout.Button("Generate Tile Map"))
        {
            rtsSceneManager.Generate();
        }
        if (GUILayout.Button("Clear Tile Map"))
        {
            rtsSceneManager.ClearTileMap();
        }
        if(GUILayout.Button("Check Grid Exist"))
        {
            rtsSceneManager.CheckGridExist();
        }

        DrawDefaultInspector();

    }
}
