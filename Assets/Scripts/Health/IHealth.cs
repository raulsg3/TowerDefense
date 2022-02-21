namespace TowerDefense
{
    public interface IHealth
    {
        public void SetHealth(float health);

        public bool IsDead();

        public void TakeDamage(float damage);

        public void Die();
    }
}
