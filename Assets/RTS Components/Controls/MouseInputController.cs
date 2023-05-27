using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //shoot ray to see if I intersect with a collider 
            
        }

        if(Input.GetMouseButtonDown(1))
        {
            //Deselecte current object if selected

        }
    }
}
