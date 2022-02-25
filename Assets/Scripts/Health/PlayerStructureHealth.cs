using UnityEngine;

namespace TowerDefense
{
    public abstract class PlayerStructureHealth : Health
    {
        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Creep))
            {
                if (other.gameObject.TryGetComponent(out ICreep creep))
                {
                    TakeDamage(creep.Damage);
                }

                if (other.gameObject.TryGetComponent(out CreepHealth creepHealth))
                {
                    creepHealth.Die();
                }
            }
        }
    }
}
