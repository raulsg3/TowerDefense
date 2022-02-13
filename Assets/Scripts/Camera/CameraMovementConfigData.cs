using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Camera/Camera Movement Configuration Data", fileName = "CameraMovementConfigData")]
    public class CameraMovementConfigData : ScriptableObject
    {
        [SerializeField]
        private float _panSpeed = 10f;

        [SerializeField]
        private float _zoomSpeed = 10f;

        public float PanSpeed => _panSpeed;
        public float ZoomSpeed => _zoomSpeed;
    }
}
