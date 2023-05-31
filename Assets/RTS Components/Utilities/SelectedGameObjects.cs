using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGameObjects : MonoBehaviour, ISelectableGameObject
{
    List<GameObject> selectedGOs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SelectGameObject()
    {
        foreach(GameObject selectedObject in selectedGOs)
        {
            if (selectedObject.GetComponent<ISelectableGameObject>() != null)
            {
                selectedObject.GetComponent<ISelectableGameObject>().SelectGameObject();
            } else
            {
                Debug.LogWarning(selectedObject.name + " Does not contain an ISelectableGameObject interface.");
            }
        }
    }

    public void DeselectGameObject()
    {
        foreach (GameObject selectedObject in selectedGOs)
        {
            if (selectedObject.GetComponent<ISelectableGameObject>() != null)
            {
                selectedObject.GetComponent<ISelectableGameObject>().DeselectGameObject();
            } else
            {
                Debug.LogWarning(selectedObject.name + " Does not contain an ISelectableGameObject interface.");
            }
        }
        selectedGOs.Clear();
    }
}
