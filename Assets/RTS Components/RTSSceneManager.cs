using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[System.Serializable]
public class RTSSceneManager : MonoBehaviour, IGrid
{
    [SerializeField] int width = 20;
    [SerializeField] int height = 20;
    [SerializeField] float cellSize = 50f;
    [SerializeField] bool showDebug = false;
    [SerializeField] Vector3 originPosition = Vector3.zero;
    [SerializeField] GridCell[,] grid;
    [SerializeField] Sprite texture;

    public Vector3 SnapToGrid(Vector3 mousePosition)
    {
        return SnapToGridLocation(mousePosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (transform.childCount == 0)
        {
            Debug.Log("Grid == null");
            grid = RTSUtilities.CustomGrid(width, height, cellSize, showDebug, this.gameObject.transform, originPosition);
        } else
        {
            grid = new GridCell[width, height];
            Debug.Log("Grid is present");
            for (int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    grid[x, y] = GameObject.Find("Cell_" + x.ToString() + "_" + y.ToString()).GetComponent<GridCell>();
                }
            }
        }
    }


    void Update()
    {
        ShowDebug();
    }

    public void CheckGridExist()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Grid == null");
        }
        else
        {
            Debug.Log("Grid is present");
        }
    }

    void ShowDebug()
    {
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            showDebug = !showDebug;
            //grid.ShowDebug(showDebug);
        }
    }

    public bool BuildPlotOpen(int[] buildValues){
        for (int w = 0; w < buildValues[2]; w++)
        {
            for (int h = 0; h < buildValues[3]; h++)
            {
                int x, y;
                GetXY(new Vector3(buildValues[0], buildValues[1], 0), out x, out y);
                GridCell checkCell = GetGridObject(w + x, h + y);
                Debug.Log("Build Area: " + (w + x).ToString() + " " + (h + y).ToString());
                if (checkCell.IsCellBuildable() == false || checkCell.IsOccupied()) { return false; }
            }
        }
        return true;
    }

    public void PlaceBuilding(int[] buildValues)
    {
        for (int w = 0; w < buildValues[2]; w++)
        {
            for (int h = 0; h < buildValues[3]; h++)
            {
                int x, y;
                GetXY(new Vector3(buildValues[0], buildValues[1], 0), out x, out y);
                GridCell buildCell = GetGridObject(w + x, h + y);
                buildCell.SetBuilding();
            }
        }
    }

    public GridCell GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            Debug.Log(grid[x,y].name);
            return grid[x, y];
        }
        else
        {
            Debug.Log("default");
            return default(GridCell);
        }
    }

    public GridCell GetGridObject(Vector3 mousePosition)
    {
        int x, y;
        GetXY(mousePosition, out x, out y);
        return grid[x, y];
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
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
        grid = RTSUtilities.CustomGrid(width, height, cellSize, showDebug, this.gameObject.transform, originPosition);
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

    public Vector3 SnapToGridLocation(Vector3 mousePosition)
    {
        GetXY(mousePosition, out int x, out int y);
        return GetWorldPosition(x, y);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }
}
