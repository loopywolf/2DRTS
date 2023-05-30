using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputController : MonoBehaviour
{
    [SerializeField] GameObject currentHoverGameObject = null;
    [SerializeField] GameObject currentSelectedGameObject = null;

    void Update()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
        Debug.Log(hit.Length.ToString());
        if (hit.Length > 0)
        {
            if (currentHoverGameObject != hit[0].transform.gameObject)
            {
                HoverOver(hit[0].transform.gameObject);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(currentSelectedGameObject != hit[0].transform.gameObject)
                {
                    SelectGameObject(hit[0].transform.gameObject);
                }
            }
        } else
        {
            HoverExit();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DeselectGameObject();
        }
    }

    void SelectGameObject(GameObject selectedObject)
    {
        DeselectGameObject();
        if(selectedObject != null)
        {
            currentSelectedGameObject = selectedObject;
            currentSelectedGameObject.GetComponent<ISelectableGameObject>()?.Select();
        }
    }

    void DeselectGameObject()
    {
        if (currentSelectedGameObject != null)
        {
            currentSelectedGameObject.GetComponent<ISelectableGameObject>()?.Deselect();
            currentSelectedGameObject = null;
        }
    }

    void HoverOver(GameObject hoverObject)
    {
        HoverExit();
        if(hoverObject != null)
        {
            currentHoverGameObject = hoverObject;
            currentHoverGameObject.GetComponent<IHoverOverObject>()?.HoverOver();
        }
    }

    void HoverExit()
    {
        if(currentHoverGameObject != null)
        {
            currentHoverGameObject.GetComponent<IHoverOverObject>()?.HoverExit();
            currentHoverGameObject = null;
        }
    }

}
