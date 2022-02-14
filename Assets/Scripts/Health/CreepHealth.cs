using UnityEngine;

namespace TowerDefense
{
    public class CreepHealth : IHealth
    {
        public override void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
