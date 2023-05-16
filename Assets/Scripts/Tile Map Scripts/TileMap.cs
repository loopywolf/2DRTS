using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileMap : MonoBehaviour
{
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    [SerializeField] List<Tile> tileListComp = new List<Tile>();

    public void AddTile(GameObject tile)
    {
        tileList.Add(tile);
        tileListComp.Add(tile.GetComponent<Tile>());
    }

    public void ConfigureTileMapNeighbors()
    {
        foreach (GameObject tile in tileList)
        {
            tile.GetComponent<Tile>().ConfigureNeighbors(tileListComp);
        }
    }
}
