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

        private Vector3 _targetDirection;
        private Quaternion _targetLookRotation;

        public abstract void Init();

        public abstract float GetTargetSearchTime();

        public abstract float GetRotationSpeed();

        private void Start()
        {
            StartCoroutine(SearchForTarget());
        }

        private void Update()
        {
            if (_currentTarget != null)
            {
                if (IsTargetAimed())
                {
                    //
                }
                else
                {
                    AimTarget();
                }
            }
            else
            {
                AimTarget();
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
            return false;
        }

        private void AimTarget()
        {
            _targetDirection = (_currentTarget.transform.position - transform.position).normalized;
            _targetLookRotation = Quaternion.LookRotation(_targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, _targetLookRotation, Time.deltaTime * GetRotationSpeed());
        }
    }
}
