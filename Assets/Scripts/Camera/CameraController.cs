using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float zoomSpeed = 10f;

    void Update()
    {
        //Camera panning
        float verticalTranslation = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;
        float horizontalTranslation = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;

        float zoomTranslation = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

        Vector3 cameraPosition = transform.position;

        cameraPosition.x += horizontalTranslation;
        cameraPosition.y -= zoomTranslation;
        cameraPosition.z += verticalTranslation;

        transform.position = cameraPosition;
    }
}
