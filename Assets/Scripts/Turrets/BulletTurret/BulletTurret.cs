using UnityEngine;

namespace TowerDefense
{
    public class BulletTurret : Turret, ITurretAim
    {
        [SerializeField]
        private BulletTurretConfigData _bulletTurretConfigData;

        [SerializeField]
        private GameObject _bulletPrefab;

        private Vector3 _targetDirection = Vector3.zero;
        private Quaternion _targetLookRotation = Quaternion.identity;

        public override void Init()
        {
            _turretHealth.SetHealth(_bulletTurretConfigData.Health);
        }

        public override float GetTargetSearchTime()
        {
            return _bulletTurretConfigData.TargetSearchTime;
        }

        public override float GetCooldownTime()
        {
            return _bulletTurretConfigData.CooldownTime;
        }

        public override bool CanShoot()
        {
            return IsTargetAimed();
        }

        public override void ShootTarget()
        {
            GameObject bulletInstance = Instantiate(_bulletPrefab, transform.position, transform.rotation);

            if (bulletInstance.TryGetComponent<Bullet>(out var bullet))
                bullet.ShootAt(_currentTarget.transform.position);
        }

        public override void WaitUntilCanShoot()
        {
            AimTarget();
        }

        private float GetRotationSpeed()
        {
            return _bulletTurretConfigData.RotationSpeed;
        }

        private float GetAimAngleThreshold()
        {
            return _bulletTurretConfigData.AimAngleThreshold;
        }

        public bool IsTargetAimed()
        {
            bool targetAimed = false;

            if (_targetDirection != Vector3.zero)
            {
                if (Vector3.Angle(transform.forward, _targetDirection) < GetAimAngleThreshold())
                    targetAimed = true;
            }

            return targetAimed;
        }

        public void AimTarget()
        {
            _targetDirection = _currentTarget.transform.position - transform.position;
            _targetDirection.y = 0;
            _targetDirection = _targetDirection.normalized;

            _targetLookRotation = Quaternion.LookRotation(_targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, _targetLookRotation, Time.deltaTime * GetRotationSpeed());
        }
    }
}
