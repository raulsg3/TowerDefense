using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    private float _panSpeed = 0f;
    private float _zoomSpeed = 0f;

    public float PanSpeed
    {
        set { _panSpeed = value; }
    }

    public float ZoomSpeed
    {
        set { _zoomSpeed = value; }
    }

    public CameraMovement(float panSpeed, float zoomSpeed)
    {
        PanSpeed = panSpeed;
        ZoomSpeed = zoomSpeed;
    }

    public Vector3 MoveCamera(Vector3 cameraPosition, float verticalInput, float horizontalInput, float scrollInput)
    {
        //Camera panning
        float verticalTranslation = Input.GetAxis("Vertical") * _panSpeed * Time.deltaTime;
        float horizontalTranslation = Input.GetAxis("Horizontal") * _panSpeed * Time.deltaTime;

        float zoomTranslation = Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed * Time.deltaTime;

        Vector3 newCameraPosition = cameraPosition;

        newCameraPosition.x += horizontalInput * _panSpeed;
        newCameraPosition.y -= scrollInput * _zoomSpeed;
        newCameraPosition.z += verticalInput * _panSpeed;

        return newCameraPosition;
    }
}
