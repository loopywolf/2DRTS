using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    GameObject selectedGameObject;

    public void SetSelectedGameObject(GameObject selectedGameObject)
    {
        DeselectSelectedGameObject();
        this.selectedGameObject = selectedGameObject;
        this.selectedGameObject.GetComponent<ISelectedGameObject>().SelectedGameObject(selectedGameObject);
    }

    public void DeselectSelectedGameObject()
    {
        this.selectedGameObject.GetComponent<ISelectedGameObject>().DeselectSelectedGameObject();
    }
}
