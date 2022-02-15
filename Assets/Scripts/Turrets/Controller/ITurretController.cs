using UnityEngine;

namespace TowerDefense
{
    public interface ITurretController
    {
        public void SetTurretTypeToPlace(Turret.EType type);

        public bool CanPlaceTurret(Vector3 position);

        public void PlaceTurret(Vector3 position);
    }
}
