using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Projectiles/Bullet Configuration Data", fileName = "BulletConfigData")]
    public class BulletConfigData : ScriptableObject
    {
        [SerializeField]
        private float _speed = 5f;

        [SerializeField]
        private float _damage = 1f;

        [SerializeField]
        private float _destroyTime = 3f;

        public float Speed => _speed;

        public float Damage => _damage;

        public float DestroyTime => _destroyTime;
    }
}
