using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingGridCell : MonoBehaviour
{

    public static PathFindingGridCell Instance;
    const int inLineCost = 10;
    const int diagonalCost = 14;

    List<GridCell> openCells = new List<GridCell>();
    List<GridCell> closedCells = new List<GridCell>();
    GridCell currentCell;


    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }
    public List<GridCell> FindPath(GridCell startCell, GridCell endCell)
    {
        openCells.Clear();
        closedCells.Clear();
        SetCalculationCosts(startCell, 0, null, endCell);
        openCells.Add(startCell);

        while (openCells.Count > 0)
        {
            currentCell = LowestCost(openCells);
            if (currentCell == endCell) return CalculatePath(currentCell);
            openCells.Remove(currentCell);
            closedCells.Add(currentCell);

            foreach (GridCell neighbor in currentCell.GetNeighbors())
            {
                if (closedCells.Contains(neighbor) || neighbor.GetWeight() > 50f) continue;
                if (!neighbor.IsCellTraversable())
                {
                    if (openCells.Contains(neighbor)) openCells.Remove(neighbor);
                    if (!closedCells.Contains(neighbor)) closedCells.Add(neighbor);
                }
                else
                {

                    int calcGCost = currentCell.gCost + CalculateDistanceCost(neighbor, currentCell);
                    if (calcGCost < neighbor.gCost || !openCells.Contains(neighbor))
                    {
                        SetCalculationCosts(neighbor, calcGCost, currentCell, endCell);

                        if (!openCells.Contains(neighbor)) openCells.Add(neighbor);
                    }
                }
            }
        }
        return null;
    }

    void SetCalculationCosts(GridCell cell, int calcGCost, GridCell currentTile, GridCell endTile)
    {

        cell.previousTile = currentTile;
        cell.gCost = calcGCost;
        cell.hCost = CalculateDistanceCost(cell, endTile);
        cell.SetFCost();
    }

    List<GridCell> CalculatePath(GridCell endCell)
    {
        List<GridCell> tilePath = new List<GridCell>();
        tilePath.Add(endCell);
        GridCell currentTile = endCell;
        while (currentTile.previousTile != null)
        {
            tilePath.Add(currentTile.previousTile);
            currentTile = currentTile.previousTile;
        }
        tilePath.Reverse();
        return tilePath;
    }

    GridCell LowestCost(List<GridCell> cells)
    {
        GridCell node = null;
        for (int x = 0; x < cells.Count; x++)
        {
            if (node == null || cells[x].fCost < node.fCost) node = cells[x];
            if (cells[x].fCost == node.fCost && cells[x].hCost < node.hCost) node = cells[x];
        }
        return node;
    }

    int CalculateDistanceCost(GridCell a, GridCell b)
    {
        int xDistance = Mathf.Abs(a.GetTilePosition()[0] - b.GetTilePosition()[0]);
        int yDistance = Mathf.Abs(a.GetTilePosition()[1] - b.GetTilePosition()[1]);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return Mathf.RoundToInt((diagonalCost * Mathf.Min(xDistance, yDistance) + inLineCost * remaining) * a.GetWeight());
    }
}
