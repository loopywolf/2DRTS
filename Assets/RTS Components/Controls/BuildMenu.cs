using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildMenu thisBuildMenu;
    [SerializeField] GameObject cellMarker;
    [SerializeField] IGrid iGrid;
    [SerializeField] bool buildEnabled = false;

    [SerializeField] GameObject buildMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(thisBuildMenu == null)
        {
            thisBuildMenu = this;
        } else
        {
            Destroy(this);
        }
        iGrid = GameObject.FindObjectOfType<RTSSceneManager>().GetComponent<IGrid>();
        buildMenu = GameObject.Find("Build Menu");
        buildMenu.SetActive(buildEnabled);
        cellMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenBuildMenu();

        SnapBuildingToGrid();

        BuildingPlacement();

        CancelBuilding();
    }

    public void BuildingSelected(int width, int height, string buildingName)
    {
        buildMenu.SetActive(false);
        SizeBuildingArray(width, height);
        buildEnabled = true;
    }

    void OpenBuildMenu()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildMenu.SetActive(!buildMenu.activeSelf);
        }
        
    }
    
    void SizeBuildingArray(int width, int height)
    {
        cellMarker.transform.localScale = new Vector3(width, height, 1);
    }

    bool ValidateBuildLocation()
    {
        return false;
    }

    void BuildingPlacement()
    {

    }

    void CancelBuilding()
    {
        if (Input.GetMouseButton(1))
        {
            buildEnabled = false; 
            buildMenu.SetActive(false);
            cellMarker.SetActive(buildEnabled);
        }
    }

    void SnapBuildingToGrid()
    {
        if (buildEnabled)
        {
            cellMarker.SetActive(buildEnabled);
            transform.position = iGrid.SnapToGrid(RTSUtilities.GetMouseWorldPosition());

            //need to check gird with ValidateBuildLocation for is 
        }
    }
}
