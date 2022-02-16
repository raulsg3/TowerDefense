using UnityEngine;

namespace TowerDefense
{
    public class PlaceTurretController : IPlaceTurretController
    {
        private ITurretSpawner _turretSpawner;

        private Turret.EType _currentTurretType = Turret.EType.Bullets;

        public PlaceTurretController(ITurretSpawner turretSpawner)
        {
            _turretSpawner = turretSpawner;
        }

        public bool IsPlacingTurret()
        {
            return true;
        }

        public void SetTurretTypeToPlace(Turret.EType type)
        {
            _currentTurretType = type;
        }

        public bool PlaceTurret(Vector3 position)
        {
            bool turretPlaced = CanPlaceTurret(position);

            if (turretPlaced)
                _turretSpawner.SpawnTurret(_currentTurretType, position);

            return turretPlaced;
        }

        private bool CanPlaceTurret(Vector3 position)
        {
            return true;
        }
    }
}
