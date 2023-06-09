using System;
using UnityEngine;
using System.Collections.Generic;

public class CustomGrid<GridCell> 
{
    [SerializeField] bool showDebug = false;

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private GridCell[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Transform parent;

    public CustomGrid(int width, int height, float cellSize, bool showDebug, Transform parent, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.showDebug = showDebug;
        this.parent = parent;

        gridArray = new GridCell[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //GameObject cell = new GameObject("Cell_" + x + "_" + y);
                //GridCell gridCell = cell.AddComponent<GridCell>();
                //gridCell.SetupGridCell(x, y);
                //gridArray[x, y] = gridCell;
            }
        }
        if (showDebug)
        {
            debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = RTSUtilities.CreateWorldText(gridArray[x, y]?.ToString(), parent, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 50, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 1f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 1f);
                }
                Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 1f);
                Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 1f);
            }
        }
    }

    public bool BuildPlotOpen(int[] buildValues)
    {
        for (int w = 0; w < buildValues[2]; w++)
        {
            for (int h = 0; h < buildValues[3]; h++)
            {
                int x, y;
                GetXY(new Vector3(buildValues[0], buildValues[1], 0), out x, out y);
                GridCell checkCell = GetGridObject(w + x, h + y);
                Debug.Log("Build Area: " + (w + x).ToString() + " " + (h + y).ToString());
                //if (checkCell.IsCellBuildable() == false) { return false; }

            }
        }
        return true;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetGridObject(int x, int y, GridCell value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetGridObject(Vector3 worldPosition, GridCell value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }

    public Vector3 SnapToGridLocation(Vector3 mousePosition)
    {
        GetXY(mousePosition, out int x, out int y);
        return GetWorldPosition(x, y);
    }

    public GridCell GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(GridCell);
        }
    }

    public GridCell GetGridObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetGridObject(x, y);
    }
}
