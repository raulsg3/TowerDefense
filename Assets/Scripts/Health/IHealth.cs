using UnityEngine;

namespace TowerDefense
{
    public abstract class IHealth : MonoBehaviour
    {
        protected float _health = 1f;

        public void SetHealth(float health)
        {
            _health = health;
        }

        public bool IsDead()
        {
            return (_health <= 0);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (IsDead())
                Die();
        }

        public abstract void Die();
    }
}
