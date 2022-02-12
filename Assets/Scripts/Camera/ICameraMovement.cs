using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraMovement
{
    public Vector3 PanCamera(Vector3 cameraPosition, float xInput, float zInput);
    public Vector3 ZoomCamera(Vector3 cameraPosition, float yInput);
}
