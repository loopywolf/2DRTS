using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] string buildingName;
    [SerializeField] int width;
    [SerializeField] int height;

    //Cost cost;
    //string owner;
    //float sightRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void BuildingSelected()
    {
        BuildMenu.thisBuildMenu.BuildingSelected(width, height, buildingName);
    }
}
