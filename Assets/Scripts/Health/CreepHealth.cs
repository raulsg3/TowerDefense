using UnityEngine;

namespace TowerDefense
{
    public class CreepHealth : Health
    {
        public override void Die()
        {
            EventManagerSingleton.Instance.CreepEliminated(this.gameObject.GetComponent<ICreep>());
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Projectile))
            {
                if (other.gameObject.TryGetComponent(out Bullet bullet))
                {
                    TakeDamage(bullet.Damage);
                }

                Destroy(other.gameObject);
            }
        }
    }
}
