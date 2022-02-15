using UnityEngine;

namespace TowerDefense
{
    public interface ITurretController
    {
        public bool IsPlacingTurret();

        public void SetTurretTypeToPlace(Turret.EType type);

        public bool PlaceTurret(Vector3 position);
    }
}
