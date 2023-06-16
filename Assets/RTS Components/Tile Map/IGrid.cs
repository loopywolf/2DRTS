using UnityEngine;

public interface IGrid
{
    public Vector3 SnapToGrid(Vector3 mousePosition);

    public bool BuildPlotOpen(int[] buildingValues);

    public void PlaceBuilding(int[] buildingValues);

    public GridCell GetGridObject(int x, int y);
}
