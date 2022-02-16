using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public abstract class Turret : MonoBehaviour
    {
        public enum EType
        {
            Bullets
        }

        [SerializeField]
        protected EType _type;

        [SerializeField]
        protected IHealth _turretHealth;

        public EType Type => _type;

        protected Creep _currentTarget = null;

        private Vector3 _targetDirection = Vector3.zero;
        private Quaternion _targetLookRotation = Quaternion.identity;

        private float _remainingCooldownTime = 0f;

        public abstract void Init();

        public abstract float GetTargetSearchTime();
        public abstract float GetRotationSpeed();
        public abstract float GetAimAngleThreshold();
        public abstract float GetCooldownTime();

        public abstract void ShootTarget();

        private void Start()
        {
            ResetCooldown();
            StartCoroutine(SearchForTarget());
        }

        private void Update()
        {
            _remainingCooldownTime -= Time.deltaTime;

            if (_currentTarget != null)
            {
                if (!IsOnCooldown() && IsTargetAimed())
                {
                    ShootTarget();
                    ResetCooldown();
                }
                else
                {
                    AimTarget();
                }
            }
            else
            {
                SearchForNearestTarget();
            }
        }

        private IEnumerator SearchForTarget()
        {
            WaitForSeconds waitNextTargetSearch = new WaitForSeconds(GetTargetSearchTime());

            while (true)
            {
                SearchForNearestTarget();
                yield return waitNextTargetSearch;
            }
        }

        private void SearchForNearestTarget()
        {
            GameObject[] creeps = GameObject.FindGameObjectsWithTag(Tags.Creep);
            GameObject nearestTarget = FindUtils.FindClosestGameObject(creeps, transform.position);

            nearestTarget?.TryGetComponent<Creep>(out _currentTarget);
        }

        private bool IsTargetAimed()
        {
            bool targetAimed = false;

            if (_targetDirection != Vector3.zero)
            {
                if (Vector3.Angle(transform.forward, _targetDirection) < GetAimAngleThreshold())
                    targetAimed = true;
            }

            return targetAimed;
        }

        private void AimTarget()
        {
            _targetDirection = _currentTarget.transform.position - transform.position;
            _targetDirection.y = 0;
            _targetDirection = _targetDirection.normalized;

            _targetLookRotation = Quaternion.LookRotation(_targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, _targetLookRotation, Time.deltaTime * GetRotationSpeed());
        }

        private void ResetCooldown()
        {
            _remainingCooldownTime = GetCooldownTime();
        }

        private bool IsOnCooldown()
        {
            return (_remainingCooldownTime > 0f);
        }
    }
}
