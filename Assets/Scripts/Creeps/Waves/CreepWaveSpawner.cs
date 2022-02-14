using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepWaveSpawner : ICreepWaveSpawner
    {
        private ICreepFactory _creepFactory;

        private readonly MonoBehaviour _monoBehaviourReference;

        private Vector3 _targetPosition;

        public CreepWaveSpawner(ICreepFactory creepFactory, MonoBehaviour monoBehaviourReference, Vector3 targetPosition)
        {
            _creepFactory = creepFactory;
            _monoBehaviourReference = monoBehaviourReference;
            _targetPosition = targetPosition;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
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
                    Creep newCreep = _creepFactory.Create(numCreepsByType.Key);
                    newCreep.Init(_targetPosition);
                    yield return waitBetweenCreeps;
                }
            }

        }
    }
}
