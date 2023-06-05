using UnityEngine;

[ExecuteInEditMode]

public class RTSSceneManager : MonoBehaviour, IGrid
{
    [SerializeField] int width = 20;
    [SerializeField] int height = 20;
    [SerializeField] float tileSize = 50f;
    [SerializeField] bool showDebug = false;
    CustomGrid<GridCell> grid;

    [SerializeField] Sprite texture;

    public Vector3 SnapToGrid(Vector3 mousePosition)
    {
        return grid.SnapToGridLocation(mousePosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new CustomGrid<GridCell>(width, height, tileSize, false, this.gameObject.transform, new Vector3(10f, 0), (int x, int y) => new GridCell(x, y));
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


        return grid.BuildPlotOpen(buildValues);
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

        grid = new CustomGrid<GridCell>(width, height, tileSize, showDebug, this.gameObject.transform, new Vector3(10f, 0), (int x, int y) => new GridCell(x, y));

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
}
