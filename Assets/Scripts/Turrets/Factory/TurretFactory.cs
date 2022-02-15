using UnityEngine;

namespace TowerDefense
{
    public class TurretFactory : ITurretFactory
    {
        private readonly TurretFactoryConfigData _turretFactoryConfigData;

        public TurretFactory(TurretFactoryConfigData turretFactoryConfigData)
        {
            _turretFactoryConfigData = turretFactoryConfigData;
        }

        public Turret Create(Turret.EType type)
        {
            Turret turretPrefab = _turretFactoryConfigData.GetTurretByType(type);
            return GameObject.Instantiate(turretPrefab);
        }
    }
}
