using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseSelection : MonoBehaviour
{
    [SerializeField] Camera cam;


    [SerializeField] List<GameObject> selectedUnits = new List<GameObject>();
    [SerializeField] TileMap map;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    void Start()
    {
        GameObject.FindWithTag("TileMap");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit2D[] hit  = Physics2D.RaycastAll(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
            if(hit.Length > 0)
            {
                Debug.Log("Hit does not = null\n" + hit.Length.ToString());
                if (hit[0].transform.CompareTag("Player"))
                {
                    selectedUnits.Clear();
                    selectedUnits.Add(hit[0].transform.gameObject);
                } 
                if(hit[0].transform.CompareTag("Tile"))
                {
                    Debug.Log("Clicked Tile");
                    if(selectedUnits.Count > 0)
                    {
                        foreach (GameObject unit in selectedUnits)
                        {
                            tiles.Clear();
                            tiles = map.GetComponent<PathFinding>().FindPath(unit.GetComponent<CharacterMovement>().CurrentTile(), hit[0].transform.gameObject.GetComponent<Tile>());
                            unit.GetComponent<CharacterMovement>().SetMovementList(tiles);
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
            if (hit.Length > 0)
            {
                if (hit[0].transform.CompareTag("Player"))
                {
                    selectedUnits.Add(hit[0].transform.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            selectedUnits.Clear();
        }
    }
}
