using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteInEditMode]

public class TileMapGenerator : MonoBehaviour
{
    [SerializeField] float tileSize = 1.25f;
    [SerializeField] int height;
    [SerializeField] int width;


    //Temp variables
    [SerializeField] Sprite texture;


    void Update()
    {

    }

    public void Generate()
    {
        //dispose of any existing tiles
        //create new array
        Debug.Log("Generate Map");
        if (height > 0 && width > 0)
        {
            GenerateMap();
        } else
        {
            Debug.LogError("Can not generate tile map with Height or Width of size smaller then or equal to zero!");
        }
    }

    void GenerateMap()
    {
        if(GameObject.FindWithTag("TileMap") != null)
        {
            ClearTileMap();
        }

        GameObject tileMap = CreateTileMap();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CreateTile(x, y,tileMap);
            }
        }
        tileMap.GetComponent<TileMap>().ConfigureTileMapNeighbors();
    }

    public void ClearTileMap()
    {
        if (GameObject.FindWithTag("TileMap") != null)
        {
            GameObject tileMap = GameObject.FindWithTag("TileMap");

            if (tileMap.transform.childCount > 0)
            {
                Debug.Log("Children Count: " + tileMap.transform.childCount);
                for (int x = tileMap.transform.childCount - 1; x > -1; x--)
                {
                    DestroyImmediate(tileMap.transform.GetChild(x).gameObject);
                }
                DestroyImmediate(tileMap);
            } else
            {
                Debug.Log("No children to remove.");
            }
        } else { 
            Debug.Log("No TileMap object found, TileMap tag may have been removed or manual removal may be required");
        }
    }

    GameObject CreateTileMap()
    {
        GameObject tileMap = new GameObject("TileMap");
        tileMap.transform.position = Vector3.zero;
        tileMap.tag = "TileMap";
        tileMap.AddComponent<TileMap>();
        return tileMap;
    }

    void CreateTile(int xLocation, int yLocation, GameObject tileMap)
    {
        //Can be updated with prefab if warrented
        GameObject newTile = new("Tile_" + xLocation.ToString() + "_" + yLocation.ToString());
        newTile.transform.parent = tileMap.transform;
        newTile.transform.position = new Vector3(xLocation * tileSize + (tileSize * .5f) - (tileSize * width * .5f), yLocation * tileSize + (tileSize * .5f) - (tileSize * height * .5f), 0f);
        SpriteRenderer assignTexture = newTile.AddComponent<SpriteRenderer>();
        assignTexture.sprite = texture;
        Tile tileComp = newTile.AddComponent<Tile>();
        tileComp.SetTilePosition(xLocation, yLocation);
        tileMap.GetComponent<TileMap>().AddTile(newTile);
    }
}
