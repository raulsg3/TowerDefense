using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public abstract class Turret : MonoBehaviour, ITurretShoot
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

        private float _remainingCooldownTime = 0f;

        public abstract void Init();

        public abstract float GetTargetSearchTime();

        public abstract float GetCooldownTime();

        public abstract bool CanShoot();

        public abstract void ShootTarget();

        public abstract void WaitUntilCanShoot();

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
                if (!IsOnCooldown() && CanShoot())
                {
                    ShootTarget();
                    ResetCooldown();
                }
                else
                {
                    WaitUntilCanShoot();
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
