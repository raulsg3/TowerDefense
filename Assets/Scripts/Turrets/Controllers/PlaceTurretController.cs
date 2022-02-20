using UnityEngine;

namespace TowerDefense
{
    public class PlaceTurretController : IPlaceTurretController
    {
        private ITurretSpawner _turretSpawner;

        private IEconomyController _economyController;

        private Turret.EType _currentTurretType = Turret.EType.Bullets;

        public PlaceTurretController(ITurretSpawner turretSpawner, IEconomyController economyController)
        {
            _turretSpawner = turretSpawner;
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

        public void PlaceTurret(Vector3 position)
        {
            if (CanPlaceTurret(position))
            {
                _turretSpawner.SpawnTurret(_currentTurretType, position);
                EventManagerSingleton.Instance.DeactivateTurretPlacing();
            }
        }

        private bool CanPlaceTurret(Vector3 position)
        {
            return _economyController.SpendCoins(5);
        }
    }
}
