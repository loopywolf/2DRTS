

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GridCell : MonoBehaviour
{
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] string cellName;
    [SerializeField] bool cellUncovered;
    [SerializeField] bool cellInSightRange;
    [SerializeField] bool cellTraversable;
    [SerializeField] bool cellBuildable;
    [SerializeField] bool cellOccupied;
    [SerializeField] GameObject debugTextMesh;

    public GridCell previousTile;
    public int gCost;
    public int hCost;
    public int fCost;
    [SerializeField] float travelWeight = 1f;
    [SerializeField] List<GridCell> neighbors;


    public bool IsCellTraversable()
    {
        return cellTraversable;
    }

    public void SetFCost()
    {
        fCost = gCost + hCost;
    }

    public int[] GetTilePosition()
    {
        return new int[] { x, y};
    }

    public void SetDebugTextMesh(GameObject textMesh)
    {
        this.debugTextMesh = textMesh;
    }

    public void ShowDebug(bool debug)
    {
        debugTextMesh.SetActive(debug);
    }


    public void SetupGridCell(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.cellName = "Cell_" + x + "_" + y;
        this.cellUncovered = false;
        this.cellInSightRange = false;
        this.cellTraversable = true;
        this.cellBuildable = true;
        this.cellOccupied = false;
    }
    public void CellUncovered()
    {
        cellUncovered = true;
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;            
    }

    public void CellUncovered(bool value)
    {
        cellUncovered = value;
    }

    public bool IsCellUncovered()
    {
        return cellUncovered;
    }

    public void CellInSightRange(bool value)
    {
        cellInSightRange = value;
    }

    public bool IsCellInSightRange()
    {
        return cellUncovered;
    }

    public bool IsCellBuildable()
    {
        return cellBuildable;
    }

    public void SetBuilding()
    {
        cellOccupied = true;
        cellTraversable = false;
        UpdateText();
    }

    public float GetWeight()
    {
        return travelWeight;
    }

    public List<GridCell> GetNeighbors()
    {
        return neighbors;
    }

    public bool IsOccupied()
    {
        return cellOccupied;
    }

    public void CellBuildablility(bool cellBuildable)
    {
        this.cellBuildable = cellBuildable;
    }

    void UpdateText()
    {
        debugTextMesh.GetComponent<TextMesh>().text = ToString();
        if (cellOccupied)
        {
            debugTextMesh.GetComponent<TextMesh>().color = Color.red;
        } else
        {
            debugTextMesh.GetComponent<TextMesh>().color = Color.white;
        }
        
    }

    public override string ToString()
    {
        return cellName + "\nCell explored: " + cellUncovered.ToString() + "\nCell visiable: " + cellInSightRange.ToString() + "\nCell traversable: " + cellTraversable.ToString() + "\nCell buildable: " + cellBuildable.ToString() + "\nCell Occupied: " + cellOccupied.ToString();
    }

    public void ConfigureNeighbors(List<GridCell> cellList)
    {
        for (int cell = 0; cell < cellList.Count; cell++)
        {
            int[] tilePosition = cellList[cell].GetComponent<GridCell>().GetTilePosition();
            int neightborX = tilePosition[0];
            int neightborY = tilePosition[1];
            if (x == neightborX && (y == neightborY + 1 || y == neightborY - 1) || y == neightborY && (x == neightborX + 1 || x == neightborX - 1))
            {
                //These connections will be in line with the tile, and should have a value of travelWeight(default 1)
                neighbors.Add(cellList[cell]);
            }
            if (x == neightborX + 1 && (y == neightborY + 1 || y == neightborY - 1) || x == neightborX - 1 && (y == neightborY + 1 || y == neightborY - 1))
            {
                //These connections are diagonal and should carry a slightly greater value then 1.5.
                //Value slightly above 1.5 will prevent A* from creating a jagged tooth pattern. 
                neighbors.Add(cellList[cell]);
            }
        }
    }
}
