using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSSceneManager : MonoBehaviour, IGrid
{
    [SerializeField] int width = 20;
    [SerializeField] int height = 20;
    [SerializeField] float tileSize = 50f;
    [SerializeField] bool showDebug = false;
    private Grid<GridCell> grid;

    public Vector3 SnapToGrid(Vector3 mousePosition)
    {
        return grid.SnapToGridLocation(mousePosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<GridCell>(width, height, tileSize, showDebug, new Vector3(10f, 0), (int x, int y) => new GridCell(x, y));
    }
}
