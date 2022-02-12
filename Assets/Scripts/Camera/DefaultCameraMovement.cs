using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DefaultCameraMovement : ICameraMovement
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

        public DefaultCameraMovement(float panSpeed, float zoomSpeed)
        {
            PanSpeed = panSpeed;
            ZoomSpeed = zoomSpeed;
        }

        public Vector3 PanCamera(Vector3 cameraPosition, float xInput, float zInput)
        {
            Vector3 newCameraPosition = cameraPosition;

            newCameraPosition.x += xInput * _panSpeed;
            newCameraPosition.z += zInput * _panSpeed;

            return newCameraPosition;
        }

        public Vector3 ZoomCamera(Vector3 cameraPosition, float yInput)
        {
            Vector3 newCameraPosition = cameraPosition;

            newCameraPosition.y -= yInput * _zoomSpeed;

            return newCameraPosition;
        }
    }

}
