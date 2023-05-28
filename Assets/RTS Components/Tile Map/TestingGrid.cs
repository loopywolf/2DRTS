using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private Grid<GridCell> grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<GridCell>(20, 20, 50f, new Vector3(10f, 0), (int x, int y) => new GridCell(x, y));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        grid.SetGridObject(RTSUtilities.GetMouseWorldPosition(), new GridCell(1, 1));
    //    }

    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Debug.Log(grid.GetGridObject(RTSUtilities.GetMouseWorldPosition()).ToString());
    //    }
    //}
}
