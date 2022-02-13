using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepWaveSpawner : ICreepWaveSpawner
    {
        private ICreepFactory _creepFactory;

        private readonly MonoBehaviour _monoBehaviourReference;

        public CreepWaveSpawner(ICreepFactory creepFactory, MonoBehaviour monoBehaviourReference)
        {
            _creepFactory = creepFactory;
            _monoBehaviourReference = monoBehaviourReference;
        }

        public void StartWaveSpawn(CreepWave creepWave)
        {
            _monoBehaviourReference.StartCoroutine(SpawnWave(creepWave));
        }

        private IEnumerator SpawnWave(CreepWave creepWave)
        {
            WaitForSeconds waitBetweenCreeps = new WaitForSeconds(creepWave.TimeBetweenCreeps);

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
