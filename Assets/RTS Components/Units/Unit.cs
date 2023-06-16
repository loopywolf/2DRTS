using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour, IMoveLocation
{
    string unitName;
    Image icon;
    int[,] buildingSize;
    Cost cost;
    string owner;
    float sightRange;
    float engagementRange;
    [SerializeField] GridCell moveLocation;

    public void MoveLocation(GridCell gridCell)
    {
        moveLocation = gridCell;
    }

    public void Update()
    {
        MoveUnit();
    }

    void MoveUnit()
    {
        if(moveLocation != null)
        {
            transform.position = moveLocation.transform.position;
            moveLocation = null;
        }
    }
}
