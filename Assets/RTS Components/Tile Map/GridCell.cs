using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    int x;
    int y;
    string cellName;
    bool cellUncovered;
    bool cellInSightRange;

    public GridCell(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.cellName = "Cell_" + x + "_" + y;
        this.cellUncovered = false;
        this.cellInSightRange = false;
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

    public override string ToString()
    {
        return cellName + "\n" + cellUncovered.ToString();
    }
}
