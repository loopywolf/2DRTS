using System;
using UnityEngine;
using System.Collections.Generic;

public class CustomGrid<TGridObject> 
{
    [SerializeField] bool showDebug = false;

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Transform parent;

    public CustomGrid(int width, int height, float cellSize, bool showDebug, Transform parent, Vector3 originPosition, Func<int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.showDebug = showDebug;
        this.parent = parent;

        gridArray = new TGridObject[width, height];

        for(int x =0; x < gridArray.GetLength(0); x++)
        {
            for( int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(x, y);
            }
        }
        if (showDebug) { 
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
        for(int x = buildValues[0]; x < buildValues[2]; x++)
        {
            for(int y = buildValues[1]; y < buildValues[3]; y++)
            {
                Debug.Log("Build Area: " + x.ToString() + " " + y.ToString());
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

    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }

    public Vector3 SnapToGridLocation(Vector3 mousePosition)
    {
        GetXY(mousePosition, out int x, out int y);
        return GetWorldPosition(x, y);
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        } else
        {
            return default(TGridObject);
        }
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetGridObject(x, y);
    }
}
