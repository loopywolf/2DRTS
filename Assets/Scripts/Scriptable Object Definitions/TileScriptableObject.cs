using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileName", menuName = "Custom Scriptable Objects/Tile", order = 1)]
public class TileScriptableObject : ScriptableObject
{
    [SerializeField] string tileName;
    [SerializeField] Texture2D texture;
    [SerializeField] bool occupied;
    [SerializeField] List<TileScriptableObject> neighbors = new List<TileScriptableObject>();
}
