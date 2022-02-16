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
        private float _cooldownTime = 1f;

        [SerializeField]
        private float _range = 1f;

        [SerializeField]
        private float _bulletDamage = 1f;

        public float Health => _health;

        public float TargetSearchTime => _targetSearchTime;

        public float CooldownTime => _cooldownTime;

        public float Range => _range;

        public float BulletDamage => _bulletDamage;
    }
}

