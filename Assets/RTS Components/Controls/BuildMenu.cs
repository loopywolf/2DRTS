using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildMenu thisBuildMenu;
    [SerializeField] GameObject cellMarker;
    [SerializeField] IGrid iGrid;
    [SerializeField] bool buildEnabled = false;
    [SerializeField] bool isBuilding = false;

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
        BuildingPlacement();

        OpenBuildMenu();

        SnapBuildingToGrid();

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
        isBuilding = true;
    }

    bool ValidateBuildLocation()
    {
        int[] buildValue = new int[4];
        buildValue[0] = (int) cellMarker.transform.position.x;
        buildValue[1] = (int) cellMarker.transform.position.y;
        buildValue[2] = (int) cellMarker.transform.localScale.x;
        buildValue[3] = (int) cellMarker.transform.localScale.y;
        Debug.Log("Build Values " + buildValue[0].ToString() + "," + buildValue[1].ToString() + "," + buildValue[2].ToString() + "," + buildValue[3].ToString());
        return iGrid.BuildPlotOpen(buildValue);
    }

    void BuildingPlacement()
    {
        if (Input.GetMouseButtonDown(0) && isBuilding)
        {
            if (ValidateBuildLocation())
            {
                Debug.Log("Place Building!");
                CancelBuilding();
            }

        }
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
