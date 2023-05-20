using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    const int inLineCost = 10;
    const int diagonalCost = 14;

    List<Tile> openTiles = new List<Tile>();
    List<Tile> closedTiles = new List<Tile>();
    Tile currentTile;
    
    public List<Tile> FindPath(Tile startTile, Tile endTile)
    {
        openTiles.Clear();
        closedTiles.Clear();
        SetCalculationCosts( startTile, 0, null, endTile);
        openTiles.Add(startTile);
        
        while(openTiles.Count > 0)
        {
            currentTile = LowestCost(openTiles);
            if(currentTile == endTile) return CalculatePath(currentTile);
            openTiles.Remove(currentTile);
            closedTiles.Add(currentTile);

            foreach(Tile neighbor in currentTile.GetNeighbors())
            {
                if (closedTiles.Contains(neighbor) || neighbor.GetWeight() > 50f) continue;
                
                int calcGCost = currentTile.gCost + CalculateDistanceCost(neighbor, currentTile);
                if(calcGCost < neighbor.gCost || !openTiles.Contains(neighbor))
                {
                    SetCalculationCosts(neighbor, calcGCost, currentTile, endTile);
                    
                    if(!openTiles.Contains(neighbor)) openTiles.Add(neighbor);
                }
            }
        }
        return null;
    }

    void SetCalculationCosts(Tile tile, int calcGCost, Tile currentTile, Tile endTile)
    {
        
        tile.previousTile = currentTile;
        tile.gCost = calcGCost;
        tile.hCost = CalculateDistanceCost(tile, endTile);
        tile.SetFCost();
    }

    List<Tile> CalculatePath(Tile endTile)
    {
        List<Tile> tilePath = new List<Tile>();
        tilePath.Add(endTile);
        Tile currentTile = endTile;
        while(currentTile.previousTile != null)
        {
            tilePath.Add(currentTile.previousTile);
            currentTile = currentTile.previousTile;
        }
        tilePath.Reverse();
        return tilePath;   
    }

    Tile LowestCost(List<Tile> tiles)
    {
        Tile node = null;
        for(int x = 0; x < tiles.Count; x++)
        {
            if (node == null || tiles[x].fCost < node.fCost) node = tiles[x];
            if (tiles[x].fCost == node.fCost && tiles[x].hCost < node.hCost) node = tiles[x];
        }
        return node;
    }

    int CalculateDistanceCost(Tile a, Tile b)
    {
        int xDistance = Mathf.Abs(a.GetTilePosition()[0] - b.GetTilePosition()[0]);
        int yDistance = Mathf.Abs(a.GetTilePosition()[1] - b.GetTilePosition()[1]);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return Mathf.RoundToInt((diagonalCost * Mathf.Min(xDistance, yDistance) + inLineCost * remaining) * a.GetWeight());
    }
}
