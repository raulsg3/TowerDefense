using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class CreepWaveSpawner : ICreepWaveSpawner
    {
        private CreepFactory _creepFactory;

        public CreepWaveSpawner(CreepFactory creepFactory)
        {
            _creepFactory = creepFactory;
        }

        public override void StartWaveSpawn(CreepWave creepWave)
        {
            StartCoroutine(SpawnWave(creepWave));
        }

        private IEnumerator SpawnWave(CreepWave creepWave)
        {
            WaitForSeconds waitBetweenCreeps = new WaitForSeconds(1);

            foreach (var numCreepsByType in creepWave.NumCreepsByType)
            {
                for (int creep = 0; creep < numCreepsByType.Value; ++creep)
                {
                    _creepFactory.Create(numCreepsByType.Key);
                    yield return waitBetweenCreeps;
                }
            }

        }
    }
}
