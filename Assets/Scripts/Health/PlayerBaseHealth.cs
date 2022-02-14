using UnityEngine;

namespace TowerDefense
{
    public class PlayerBaseHealth : PlayerStructureHealth
    {
        public override void Die()
        {
            EventManagerSingleton.Instance.PlayerBaseDestroyed();
        }
    }
}
