using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWheelScroll : MonoBehaviour
{
    [SerializeField] ICameraZoom cameraZoom;

    private void Awake()
    {
        if(cameraZoom == null)
        {
            if (GetComponent<ICameraZoom>() != null)
            {
                cameraZoom = GetComponent<ICameraZoom>();
            } else
            {
                Debug.LogWarning("ICameraZoom component is unassigned and could not be located. Please assign or ensure component is in the scene.");
            }
        }
    }

    void Update()
    {
        cameraZoom.CameraZoomFloat(Input.GetAxis("Mouse ScrollWheel"));
    }
}
