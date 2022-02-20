using UnityEngine;

namespace TowerDefense
{
    public interface IPlaceTurretController
    {
        public bool IsPlacingTurret();

        public void SetTurretTypeToPlace(Turret.EType type);

        public void PlaceTurret(Vector3 position);
    }
}
