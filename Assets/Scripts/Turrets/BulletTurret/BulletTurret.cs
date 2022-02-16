using UnityEngine;

namespace TowerDefense
{
    public class BulletTurret : Turret
    {
        [SerializeField]
        private BulletTurretConfigData _bulletTurretConfigData;

        [SerializeField]
        private GameObject _bulletPrefab;

        public override void Init()
        {
            _turretHealth.SetHealth(_bulletTurretConfigData.Health);
        }

        public override float GetTargetSearchTime()
        {
            return _bulletTurretConfigData.TargetSearchTime;
        }

        public override float GetRotationSpeed()
        {
            return _bulletTurretConfigData.RotationSpeed;
        }

        public override float GetAimAngleThreshold()
        {
            return _bulletTurretConfigData.AimAngleThreshold;
        }

        public override float GetCooldownTime()
        {
            return _bulletTurretConfigData.CooldownTime;
        }

        public override void ShootTarget()
        {
            GameObject bulletInstance = Instantiate(_bulletPrefab, transform.position, transform.rotation);

            if (bulletInstance.TryGetComponent<Bullet>(out var bullet))
                bullet.ShootAt(_currentTarget.transform.position);
        }
    }
}
