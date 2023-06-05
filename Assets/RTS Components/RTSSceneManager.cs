using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class RTSSceneManager : MonoBehaviour, IGrid
{
    [SerializeField] int width = 20;
    [SerializeField] int height = 20;
    [SerializeField] float tileSize = 50f;
    [SerializeField] bool showDebug = false;
    private Grid<GridCell> grid;

    [SerializeField] Sprite texture;

    public Vector3 SnapToGrid(Vector3 mousePosition)
    {
        return grid.SnapToGridLocation(mousePosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        //grid = new Grid<GridCell>(width, height, tileSize, showDebug, new Vector3(10f, 0), (int x, int y) => new GridCell(x, y));
    }


    public void Generate()
    {
        if (height > 0 && width > 0)
        {
            GenerateMap();
        }
        else
        {
            Debug.LogError("Can not generate tile map with Height or Width of size smaller then or equal to zero!");
        }
    }

    void GenerateMap()
    {
        if (grid != null)
        {
            ClearTileMap();
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CreateTile(x, y);
            }
        }
        //tileMap.GetComponent<TileMap>().ConfigureTileMapNeighbors();
    }

    public void ClearTileMap()
    {
        if (gameObject.transform.childCount > 0)
        {
            Debug.Log("Children Count: " + gameObject.transform.childCount);
            for (int x = gameObject.transform.childCount - 1; x > -1; x--)
            {
                DestroyImmediate(gameObject.transform.GetChild(x).gameObject);
            }
        }
        else
        {
            Debug.Log("No children to remove.");
        }
    }
    
    void CreateTile(int xLocation, int yLocation)
    {
        //Can be updated with prefab if warrented
        GameObject newTile = new("Tile_" + xLocation.ToString() + "_" + yLocation.ToString());
        newTile.transform.parent = gameObject.transform;
        newTile.transform.position = new Vector3(xLocation * tileSize + (tileSize * .5f) - (tileSize * width * .5f), yLocation * tileSize + (tileSize * .5f) - (tileSize * height * .5f), 0f);
        SpriteRenderer assignTexture = newTile.AddComponent<SpriteRenderer>();
        assignTexture.sprite = texture;
        GridCell tileComp = newTile.AddComponent<GridCell>();
        tileComp.SetPosition(xLocation, yLocation);
    }


}
