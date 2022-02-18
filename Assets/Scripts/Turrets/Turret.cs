using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public abstract class Turret : MonoBehaviour, ITurret
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

        private float _remainingCooldownTime = 0f;

        public abstract float GetHealth();

        public abstract float GetCooldownTime();

        public abstract void PerformAction();

        public abstract void WaitUntilCanPerformAction();

        public void Init()
        {
            _turretHealth.SetHealth(GetHealth());
        }

        public virtual bool CanPerformAction()
        {
            return !IsOnCooldown();
        }

        protected virtual void Start()
        {
            ResetCooldown();
        }

        protected virtual void Update()
        {
            _remainingCooldownTime -= Time.deltaTime;

            if (CanPerformAction())
            {
                PerformAction();
                ResetCooldown();
            }
            else
            {
                WaitUntilCanPerformAction();
            }
        }

        protected void ResetCooldown()
        {
            _remainingCooldownTime = GetCooldownTime();
        }

        protected bool IsOnCooldown()
        {
            return (_remainingCooldownTime > 0f);
        }
    }
}
