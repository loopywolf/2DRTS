using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TileMap tileMap = (TileMap)target;
        if (GUILayout.Button("Generate Tile Map"))
        {
            tileMap.Generate();
        }
        if (GUILayout.Button("Clear Tile Map"))
        {
            tileMap.ClearTileMap();
        }

        DrawDefaultInspector();
        
    }
}
