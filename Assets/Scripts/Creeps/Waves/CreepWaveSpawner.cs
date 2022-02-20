using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepWaveSpawner : ICreepWaveSpawner
    {
        private readonly ICreepFactory _creepFactory;

        private readonly ISpawnPointsController _spawnPointsController;

        private Vector3 _targetPosition;

        private readonly MonoBehaviour _monoBehaviourReference;

        public CreepWaveSpawner(ICreepFactory creepFactory, ISpawnPointsController spawnPointsController,
            Vector3 targetPosition, MonoBehaviour monoBehaviourReference)
        {
            _creepFactory = creepFactory;
            _spawnPointsController = spawnPointsController;
            _targetPosition = targetPosition;
            _monoBehaviourReference = monoBehaviourReference;
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
                    newCreep.transform.position = _spawnPointsController.GetRandomSpawnPoint();
                    newCreep.Init(_targetPosition);

                    EventManagerSingleton.Instance.CreepSpawned();

                    yield return waitBetweenCreeps;
                }
            }
        }
    }
}
