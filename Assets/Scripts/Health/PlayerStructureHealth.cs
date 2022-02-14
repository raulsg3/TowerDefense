using UnityEngine;

namespace TowerDefense
{
    public abstract class PlayerStructureHealth : IHealth
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Creep))
            {
                if (TryGetComponent(out Creep creep))
                {
                    TakeDamage(creep.Damage);
                }
            }
        }
    }
}
