using UnityEngine;

namespace TowerDefense
{
    public interface ITurretSpawner
    {
        public void SpawnTurret(Turret.EType type, Vector3 position);
    }
}
