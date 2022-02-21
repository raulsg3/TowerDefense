using UnityEngine;

namespace TowerDefense
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        protected IHealthView _healthView;

        protected float _maxHealth = 1f;
        protected float _health = 1f;

        public abstract void Die();

        public void SetHealth(float health)
        {
            _maxHealth = health;
            _health = health;

            UpdateView();
        }

        public bool IsDead()
        {
            return (_health <= 0);
        }

        public void TakeDamage(float damage)
        {
            if (!IsDead())
            {
                _health -= damage;

                if (_health < 0f)
                    _health = 0f;

                UpdateView();

                if (IsDead())
                    Die();
            }
        }

        protected void UpdateView()
        {
            _healthView?.UpdateHealth(CalculateHealth());
        }

        protected float CalculateHealth()
        {
            return (_health / _maxHealth);
        }
    }
}
