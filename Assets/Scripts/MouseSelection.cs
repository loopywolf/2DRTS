using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseSelection : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] GameObject currentSelected = null;
    [SerializeField] TileMap map;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    void Start()
    {
        GameObject.FindWithTag("TileMap");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit  = Physics2D.RaycastAll(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
            if(hit.Length > 0)
            {
                Debug.Log("Hit does not = null\n" + hit.Length.ToString());
                if (hit[0].transform.CompareTag("Player"))
                {
                    Debug.Log("Player clicked");
                    currentSelected = hit[0].transform.gameObject;
                } 
                if(hit[0].transform.CompareTag("Tile"))
                {
                    Debug.Log("Clicked Tile");
                    if(currentSelected != null)
                    {
                        tiles.Clear();
                        tiles = map.GetComponent<PathFinding>().FindPath(currentSelected.GetComponent<CharacterMovement>().CurrentTile(), hit[0].transform.gameObject.GetComponent<Tile>());
                        currentSelected.GetComponent<CharacterMovement>().SetMovementList(tiles);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentSelected = null;
        }
    }
}
