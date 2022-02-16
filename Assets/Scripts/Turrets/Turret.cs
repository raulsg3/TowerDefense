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

        protected Creep _currentTarget = null;

        public EType Type => _type;

        public abstract void Init();

        public abstract float GetTargetSearchTime();

        protected void Start()
        {
            StartCoroutine(SearchForTarget());
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
    }
}
