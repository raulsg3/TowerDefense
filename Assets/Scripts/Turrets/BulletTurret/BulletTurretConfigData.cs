using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Turrets/Bullet Turret Configuration Data", fileName = "BulletTurretConfigData")]
    public class BulletTurretConfigData : ScriptableObject
    {
        [SerializeField]
        private float _health = 1f;

        [SerializeField]
        private float _targetSearchTime = 1f;

        [SerializeField]
        private float _rotationSpeed = 1f;

        [SerializeField]
        private float _aimAngleThreshold = 10f;

        [SerializeField]
        private float _cooldownTime = 1f;

        [SerializeField]
        private int _price = 5;

        public float Health => _health;

        public float TargetSearchTime => _targetSearchTime;

        public float RotationSpeed => _rotationSpeed;

        public float AimAngleThreshold => _aimAngleThreshold;

        public float CooldownTime => _cooldownTime;

        public int Price => _price;
    }
}
