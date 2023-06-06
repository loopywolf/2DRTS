using UnityEngine;

[ExecuteInEditMode]

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
        grid = RTSUtilities.CustomGrid(width, height, cellSize, showDebug, this.gameObject.transform, originPosition);
        if (grid == null)
        {
            Debug.Log("Grid == null");
        } else
        {
            Debug.Log("Grid is present");
        }
    }


    void Update()
    {
        ShowDebug();
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

    public GridCell GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return grid[x, y];
        }
        else
        {
            return default(GridCell);
        }
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
