using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] GameObject cellMarker;
    [SerializeField] IGrid iGrid;
    [SerializeField] bool buildEnabled = false;

    [SerializeField] int width;
    [SerializeField] int height;
    // Start is called before the first frame update
    void Start()
    {
        iGrid = GameObject.FindObjectOfType<RTSSceneManager>().GetComponent<IGrid>();
        cellMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildEnabled = !buildEnabled;
            cellMarker.SetActive(buildEnabled);
            cellMarker.transform.localScale = new Vector3 (width, height, 1);
        }
        if (buildEnabled)
        {
            HighlightCell();
        }        
    }

    void HighlightCell()
    {
        transform.position = iGrid.SnapToGrid(RTSUtilities.GetMouseWorldPosition());
    }
}
