using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Tile currentTile;
    [SerializeField] List<Tile> movementList = new List<Tile>();

    Vector3 fromPos = new Vector3 (0, 0, 0);
    Vector3 toPos = new Vector3 (0, 0, 0);
    float moveTime = 0f;
    float movementTime = .5f;
    void Start()
    {
        transform.position = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, transform.position.z);
    }

    void Update()
    {
        if(movementList.Count > 0)
        {
            MoveCharacter();
        }    
    }

    public Tile CurrentTile()
    {
        return currentTile;
    }

    public void UpdateTile(Tile tile)
    {
        currentTile = tile;
    }

    public void SetMovementList(List<Tile> tiles)
    {
        movementList = new List<Tile>(tiles);
        fromPos = transform.position;
        toPos = new Vector3(movementList[0].transform.position.x, movementList[0].transform.position.y, transform.position.z);

    }

    void MoveCharacter()
    {
        if(transform.position == toPos)
        {
            currentTile = movementList[0];
            movementList.RemoveAt(0);
            if (movementList.Count == 0) return;
            fromPos = transform.position;
            toPos = new Vector3(movementList[0].transform.position.x, movementList[0].transform.position.y, transform.position.z);
            moveTime = 0f;
        }
        transform.position = Vector3.Lerp(fromPos, toPos, (moveTime / (movementTime * currentTile.GetWeight())));
        moveTime += Time.deltaTime;
    }
}
