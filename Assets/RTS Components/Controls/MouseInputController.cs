using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputController : MonoBehaviour
{
    public enum ActionType {addition, subtraction, replacement, assignment};
    ActionType actionType;
    [SerializeField] GameObject currentHoverGameObject = null;
    [SerializeField] GameObject currentSelectedGameObject = null;
    [SerializeField] RTSSceneManager iGrid;

    private void Start()
    {
        iGrid = GameObject.FindObjectOfType<RTSSceneManager>().GetComponent<RTSSceneManager>();
    }

    void Update()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), -Vector2.up, 0f);
        if (currentSelectedGameObject != null && Input.GetMouseButtonDown(0))
        {
            currentSelectedGameObject.transform.parent.GetComponent<IMoveLocation>().MoveLocation(iGrid.GetGridObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
        
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
            currentSelectedGameObject.GetComponent<ISelectableGameObject>()?.SelectGameObject();
        }
    }

    void DeselectGameObject()
    {
        if (currentSelectedGameObject != null)
        {
            currentSelectedGameObject.GetComponent<ISelectableGameObject>()?.DeselectGameObject();
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
