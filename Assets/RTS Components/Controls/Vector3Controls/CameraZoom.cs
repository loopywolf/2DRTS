using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour, ICameraZoom
{
    [SerializeField] float cameraMinZoom = 3f;
    [SerializeField] float cameraMaxZoom = 10f;
    [SerializeField] float cameraZoomSpeed = 1.5f;
    [SerializeField] Camera _camera;

    float zoomfloat = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (_camera == null) _camera = Camera.main;
    }

    public void CameraZoomFloat(float cameraZoom)
    {
        zoomfloat = cameraZoom;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize + -zoomfloat * cameraZoomSpeed, cameraMinZoom, cameraMaxZoom);
    }
}
