using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildMenu thisBuildMenu;
    [SerializeField] GameObject cellMarker;
    [SerializeField] IGrid iGrid;
    [SerializeField] bool buildEnabled = false;
    [SerializeField] bool isBuilding = false;

    [SerializeField] GameObject buildMenu;
    [SerializeField] GameObject tint;
    [SerializeField] Sprite sprite;
    [SerializeField] Color green;
    [SerializeField] Color red;

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

        UpdateCellMarkerHighlight();

        CancelBuilding();

    }

    public void BuildingSelected(int width, int height, string buildingName, Sprite sprite)
    {
        this.sprite = sprite;
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
        cellMarker.transform.Find("Building Sprite").GetComponent<SpriteRenderer>().sprite = sprite;
        isBuilding = true;
    }

    void UpdateCellMarkerHighlight()
    {
        int[] buildValue = PlotSetup();
        if (ValidateBuildLocation(buildValue))
        {
            tint.GetComponent<SpriteRenderer>().color = green;
        } else
        {
            tint.GetComponent<SpriteRenderer>().color = red;
        }
    }

    bool ValidateBuildLocation(int[] buildValue)
    {
        return iGrid.BuildPlotOpen(buildValue);
    }

    void BuildingPlacement()
    {
        if (Input.GetMouseButtonDown(0) && isBuilding)
        {
            int[] buildValue = PlotSetup();
            if (ValidateBuildLocation(buildValue))
            {
                Debug.Log("Place Building!");
                SpawnBuilding(buildValue);
                SetCancelBuilding();
            }

        }
    }

    int[] PlotSetup()
    {
        int[] buildValue = new int[4];
        buildValue[0] = (int)cellMarker.transform.position.x;
        buildValue[1] = (int)cellMarker.transform.position.y;
        buildValue[2] = (int)cellMarker.transform.localScale.x;
        buildValue[3] = (int)cellMarker.transform.localScale.y;
        Debug.Log("Build Values " + buildValue[0].ToString() + "," + buildValue[1].ToString() + "," + buildValue[2].ToString() + "," + buildValue[3].ToString());
        return buildValue;
    }

    void SpawnBuilding(int[] buildValue)
    {
        iGrid.PlaceBuilding(buildValue);
    }

    void CancelBuilding()
    {
        if (Input.GetMouseButton(1))
        {
            SetCancelBuilding();
        }
    }

    void SetCancelBuilding()
    {
        isBuilding = false; 
        buildEnabled = false;
        buildMenu.SetActive(false);
        cellMarker.SetActive(buildEnabled);
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
