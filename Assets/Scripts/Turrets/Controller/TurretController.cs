using UnityEngine;

namespace TowerDefense
{
    public class TurretController : ITurretController
    {
        private ITurretSpawner _turretSpawner;

        private Turret.EType _currentTurretType = Turret.EType.Bullets;

        public TurretController(ITurretSpawner turretSpawner)
        {
            _turretSpawner = turretSpawner;
        }

        public void SetTurretTypeToPlace(Turret.EType type)
        {
            throw new System.NotImplementedException();
        }

        public bool CanPlaceTurret(Vector3 position)
        {
            return true;
        }

        public void PlaceTurret(Vector3 position)
        {
            if (CanPlaceTurret(position))
                _turretSpawner.SpawnTurret(_currentTurretType, position);
        }
    }
}
