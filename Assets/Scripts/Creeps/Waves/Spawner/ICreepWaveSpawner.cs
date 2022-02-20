using UnityEngine;

namespace TowerDefense
{
    public interface ICreepWaveSpawner
    {
        public void SetTargetPosition(Vector3 targetPosition);

        public void StartWaveSpawn(CreepWave creepWave);

        public bool IsSpawning();
    }
}
