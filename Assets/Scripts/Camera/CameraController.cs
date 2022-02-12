using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraMovement _cameraMovement;
    public float panSpeed = 10f;
    public float zoomSpeed = 10f;

    private void Start()
    {
        _cameraMovement = new CameraMovement(panSpeed, zoomSpeed);
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        Vector3 newCameraPosition = _cameraMovement.PanCamera(transform.position, horizontalInput, verticalInput);
        transform.position = _cameraMovement.ZoomCamera(newCameraPosition, scrollInput);
    }
}
