using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputController : MonoBehaviour
{
    
    void Update()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
        if (hit.Length > 0)
        {
            hit[0].transform.GetComponent<IHoverOverObject>()?.HoverOver();



            if (Input.GetMouseButtonDown(0))
            {
                //shoot ray to see if I intersect with a collider 

            }

            if (Input.GetMouseButtonDown(1))
            {
                //Deselecte current object if selected

            }
        }
    }
}
