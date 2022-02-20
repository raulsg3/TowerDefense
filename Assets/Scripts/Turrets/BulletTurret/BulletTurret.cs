using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class BulletTurret : Turret, ITurretTarget
    {
        [SerializeField]
        private BulletTurretConfigData _bulletTurretConfigData;

        [SerializeField]
        private GameObject _aimingChild;

        [SerializeField]
        private GameObject _bulletSpawnPoint;

        [SerializeField]
        private GameObject _bulletPrefab;

        private Creep _currentTarget = null;
        private Vector3 _targetDirection = Vector3.zero;
        private Quaternion _targetLookRotation = Quaternion.identity;

        public override int GetPrice()
        {
            return _bulletTurretConfigData.Price;
        }

        public override float GetHealth()
        {
            return _bulletTurretConfigData.Health;
        }

        public override float GetCooldownTime()
        {
            return _bulletTurretConfigData.CooldownTime;
        }

        public override bool CanPerformAction()
        {
            return base.CanPerformAction() && HasTarget() && IsTargetAimed();
        }

        public override void PerformAction()
        {
            GameObject bulletInstance = Instantiate(_bulletPrefab, _bulletSpawnPoint.transform.position, _bulletSpawnPoint.transform.rotation);

            if (bulletInstance.TryGetComponent<Bullet>(out var bullet))
                bullet.ShootAt(_currentTarget.transform.position);
        }

        public override void WaitUntilCanPerformAction()
        {
            if (HasTarget())
            {
                AimTarget();
            }
            else
            {
                SearchForNearestTarget();
            }
        }

        public bool HasTarget()
        {
            return (_currentTarget != null);
        }

        public IEnumerator SearchForTarget()
        {
            WaitForSeconds waitNextTargetSearch = new WaitForSeconds(GetTargetSearchTime());

            while (true)
            {
                SearchForNearestTarget();
                yield return waitNextTargetSearch;
            }
        }

        private float GetTargetSearchTime()
        {
            return _bulletTurretConfigData.TargetSearchTime;
        }

        private void SearchForNearestTarget()
        {
            GameObject[] creeps = GameObject.FindGameObjectsWithTag(Tags.Creep);
            GameObject nearestTarget = FindUtils.FindClosestGameObject(creeps, transform.position);

            nearestTarget?.TryGetComponent<Creep>(out _currentTarget);
        }

        public bool IsTargetAimed()
        {
            bool targetAimed = false;

            if (_targetDirection != Vector3.zero)
            {
                if (Vector3.Angle(_aimingChild.transform.forward, _targetDirection) < GetAimAngleThreshold())
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

            _aimingChild.transform.rotation = Quaternion.Slerp(_aimingChild.transform.rotation, _targetLookRotation, Time.deltaTime * GetRotationSpeed());
        }

        private float GetAimAngleThreshold()
        {
            return _bulletTurretConfigData.AimAngleThreshold;
        }

        private float GetRotationSpeed()
        {
            return _bulletTurretConfigData.RotationSpeed;
        }

        protected override void Start()
        {
            base.Start();
            StartCoroutine(SearchForTarget());
        }
    }
}
