using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class TurretSpawner : ITurretSpawner
    {
        private readonly ITurretFactory _turretFactory;

        public TurretSpawner(ITurretFactory turretFactory)
        {
            _turretFactory = turretFactory;
        }

        public void SpawnTurret(Turret.EType type, Vector3 position)
        {
            Turret newTurret = _turretFactory.Create(type);
            newTurret.transform.position = position;
            newTurret.Init();
        }
    }
}
