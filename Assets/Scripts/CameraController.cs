using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraScrollSpeed = 1.5f;
    [SerializeField] int pixelEdgeLimit = 25;

    Camera _camera;
    Vector3 cameraHome;

    void Start()
    {
        cameraHome = transform.position;
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x + Input.GetAxis("Mouse X") * cameraScrollSpeed, _camera.transform.position.y + Input.GetAxis("Mouse Y") * cameraScrollSpeed, _camera.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _camera.transform.position = cameraHome;
        }
        if(Input.mousePosition.x > Screen.width - pixelEdgeLimit || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _camera.transform.position = _camera.transform.position + Vector3.right * cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x < pixelEdgeLimit || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _camera.transform.position = _camera.transform.position + Vector3.left * cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - pixelEdgeLimit || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _camera.transform.position = _camera.transform.position + Vector3.up * cameraScrollSpeed * Time.deltaTime; 
        }
        if (Input.mousePosition.y < pixelEdgeLimit || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _camera.transform.position = _camera.transform.position + Vector3.down * cameraScrollSpeed * Time.deltaTime;
        }

    }
}
