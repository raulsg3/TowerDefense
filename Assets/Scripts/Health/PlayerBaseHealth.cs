using UnityEngine;

namespace TowerDefense
{
    public class PlayerBaseHealth : PlayerStructureHealth
    {
        public override void Die()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().PlayerBaseDestroyed();
        }
    }
}
