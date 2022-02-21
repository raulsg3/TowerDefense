using UnityEngine;

namespace TowerDefense
{
    public class TurretHealth : PlayerStructureHealth
    {
        [SerializeField]
        private GameObject _turretObject;

        public override void Die()
        {
            Destroy(_turretObject);
        }
    }
}
