using UnityEngine;

namespace TowerDefense
{
    public abstract class ICreepWaveSpawner : MonoBehaviour
    {
        public abstract void StartWaveSpawn(CreepWave creepWave);
    }
}
