using UnityEngine;

namespace TowerDefense
{
    public interface ICreepWaveSpawner
    {
        public void StartWaveSpawn(CreepWave creepWave);
    }
}
