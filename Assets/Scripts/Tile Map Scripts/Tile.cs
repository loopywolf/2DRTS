using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int gCost;
    public int hCost;
    public int fCost;

    public Tile previousTile;
    
    [SerializeField] List<Tile> neighbors = new List<Tile>();
    [SerializeField] float travelWeight = 1f;
    [SerializeField] int tileX;
    [SerializeField] int tileY;

    public void SetTilePosition(int xLocation, int yLocation)
    {
        tileX = xLocation;
        tileY = yLocation;
    }

    public void SetFCost()
    {
        fCost = gCost + hCost;
    }

    public int[] GetTilePosition()
    {
        return new int[] {tileX, tileY};
    }

    public List<Tile> GetNeighbors()
    {
        return neighbors;
    }

    public float GetWeight()
    {
        return travelWeight;
    }

    public void ConfigureNeighbors(List<Tile> tileList)
    {
        for(int tile = 0; tile < tileList.Count; tile++)
        {
            int[] tilePosition = tileList[tile].GetComponent<Tile>().GetTilePosition();
            int neightborX = tilePosition[0];
            int neightborY = tilePosition[1];
            if(tileX == neightborX && (tileY == neightborY + 1 || tileY == neightborY -1) || tileY == neightborY && (tileX == neightborX + 1 || tileX == neightborX - 1))
            {
                //These connections will be in line with the tile, and should have a value of travelWeight(default 1)
                neighbors.Add(tileList[tile]);
            }
            if(tileX == neightborX + 1 && (tileY == neightborY + 1 || tileY == neightborY - 1) || tileX == neightborX - 1 && (tileY == neightborY + 1 || tileY == neightborY - 1))
            {
                //These connections are diagonal and should carry a slightly greater value then 1.5.
                //Value slightly above 1.5 will prevent A* from creating a jagged tooth pattern. 
                neighbors.Add(tileList[tile]);
            }
        }
    }
}
