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
    float movementTime;
    [SerializeField] List<GridCell> moveLocation;
    [SerializeField] GridCell currentTile;

    void Start()
    {
        moveLocation = new List<GridCell>();
        
    }

    public void MoveLocation(List<GridCell> gridCell)
    {
        moveLocation = gridCell;
    }

    public GridCell GetCurrentTile()
    {
        return currentTile;
    }

    public void Update()
    {
        if(currentTile == null) currentTile = GameObject.FindObjectOfType<RTSSceneManager>().GetComponent<RTSSceneManager>().GetGridObject(transform.position);
        MoveUnit();
    }

    void MoveUnit()
    {
        if(moveLocation.Count > 0)
        {
            if (transform.position == moveLocation[0].transform.position)
            {
                currentTile = moveLocation[0];
                moveLocation.Remove(moveLocation[0]);
                movementTime = 0f;
            } else
            {
                transform.position = Vector3.Lerp(currentTile.transform.position, moveLocation[0].transform.position, movementTime * 5f);
                movementTime += Time.deltaTime;
            }
        }
    }
}
