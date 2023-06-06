

using UnityEngine;

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

    /*public GridCell(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.cellName = "Cell_" + x + "_" + y;
        this.cellUncovered = false;
        this.cellInSightRange = false;
        this.cellTraversable = false;
        this.cellBuildable = false;
        this.cellOccupied = false;
    }*/

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
        this.cellTraversable = false;
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

    public bool IsOccupied()
    {
        return cellOccupied;
    }

    public void CellBuildablility(bool cellBuildable)
    {
        this.cellBuildable = cellBuildable;
    }

    public override string ToString()
    {
        return cellName + "\nCell explored: " + cellUncovered.ToString() + "\nCell visiable: " + cellInSightRange.ToString() + "\nCell traversable: " + cellTraversable.ToString() + "\nCell buildable: " + cellBuildable.ToString() + "\nCell Occupied: " + cellOccupied.ToString();
    }
}
