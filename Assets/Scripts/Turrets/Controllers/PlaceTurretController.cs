using UnityEngine;

namespace TowerDefense
{
    public class PlaceTurretController : IPlaceTurretController
    {
        private ITurretSpawner _turretSpawner;
        private ITurretFactory _turretFactory;

        private IEconomyController _economyController;

        private Turret.EType _currentTurretType = Turret.EType.Bullets;

        public PlaceTurretController(ITurretSpawner turretSpawner, ITurretFactory turretFactory, IEconomyController economyController)
        {
            _turretSpawner = turretSpawner;
            _turretFactory = turretFactory;

            _economyController = economyController;
        }

        public bool IsPlacingTurret()
        {
            return true;
        }

        public void SetTurretTypeToPlace(Turret.EType type)
        {
            _currentTurretType = type;
        }

        public bool CanPlaceTurret(Turret.EType type)
        {
            int turretPrice = _turretFactory.GetPrice(type);
            return _economyController.SpendCoins(turretPrice);
        }

        public void PlaceTurret(Vector3 position)
        {
            if (CanPlaceTurret(_currentTurretType))
            {
                _turretSpawner.SpawnTurret(_currentTurretType, position);
                EventManagerSingleton.Instance.DeactivateTurretPlacing();
            }
        }
    }
}
