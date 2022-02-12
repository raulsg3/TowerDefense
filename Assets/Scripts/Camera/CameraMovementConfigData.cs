using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Camera/Camera Movement Configuration Data", fileName = "Camera Movement Configuration Data")]
    public class CameraMovementConfigData : ScriptableObject
    {
        [SerializeField]
        private float _panSpeed = 0f;

        [SerializeField]
        private float _zoomSpeed = 0f;

        public float PanSpeed => _panSpeed;
        public float ZoomSpeed => _zoomSpeed;
    }
}
