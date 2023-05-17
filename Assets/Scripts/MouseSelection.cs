using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    //Temp
    [SerializeField] Tile a;
    [SerializeField] Tile b;

    [SerializeField] GameObject currentSelected = null;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
            }*/

            GameObject tileMap = GameObject.FindWithTag("TileMap");
            List<Tile> tiles = tileMap.GetComponent<PathFinding>().FindPath(a, b);
            for(int x = 0; x < tiles.Count; x++)
            {
                Debug.Log(tiles[x].name);
            }

        }
    }
}
