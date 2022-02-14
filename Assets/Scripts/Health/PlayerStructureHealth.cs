﻿using UnityEngine;

namespace TowerDefense
{
    public abstract class PlayerStructureHealth : IHealth
    {
        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Creep))
            {
                if (other.gameObject.TryGetComponent(out Creep creep))
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
