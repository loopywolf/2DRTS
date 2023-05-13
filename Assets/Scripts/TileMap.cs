using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteInEditMode]

public class TileMap : MonoBehaviour
{
    [SerializeField] float tileSize = 1.25f;
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] List<GameObject> tileList = new List<GameObject>();

    //Temp variables
    [SerializeField] TileScriptableObject tile;
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
        if(tileList.Count > 0)
        {
            ClearTileMap();
        }
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                CreateTile(x, y);
            }
        }
    }

    public void ClearTileMap()
    {
        if(transform.childCount > 0)
        {
            Debug.Log("Children Count: " + transform.childCount);
            for (int x = transform.childCount - 1; x > -1; x--)
            {
                DestroyImmediate(transform.GetChild(x).gameObject);
            }
        } else
        {
            Debug.Log("No children to remove.");
        }
    }

    void CreateTile(int xLocation, int yLocation)
    {
        //Can be updated with prefab if warrented
        GameObject newTile = new("Tile_" + xLocation.ToString() + "_" + yLocation.ToString());
        newTile.transform.parent = transform;
        newTile.transform.position = new Vector3(xLocation * tileSize + (tileSize * .5f) - (tileSize * height * .5f), yLocation * tileSize + (tileSize * .5f) - (tileSize * width * .5f), 0f);
        SpriteRenderer assignTexture = newTile.AddComponent<SpriteRenderer>();
        assignTexture.sprite = texture;
        tileList.Add(newTile);
    }
}
