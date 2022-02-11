using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;

    void Update()
    {
        float verticalTranslation = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;
        float horizontalTranslation = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;

        Vector3 cameraPosition = transform.position;

        cameraPosition.x += horizontalTranslation;
        cameraPosition.z += verticalTranslation;

        transform.position = cameraPosition;
    }
}
