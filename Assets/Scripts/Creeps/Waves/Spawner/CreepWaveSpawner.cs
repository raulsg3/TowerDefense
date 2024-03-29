﻿using System.Collections;
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

        private bool _isSpawning = false;

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
            _isSpawning = true;
            _monoBehaviourReference.StartCoroutine(SpawnWave(creepWave));
        }

        public bool IsSpawning()
        {
            return _isSpawning;
        }

        private IEnumerator SpawnWave(CreepWave creepWave)
        {
            WaitForSeconds waitBetweenCreeps = new WaitForSeconds(creepWave.TimeBetweenCreeps);

            foreach (ICreep.EType creepType in creepWave.Creeps)
            {
                yield return waitBetweenCreeps;

                ICreep newCreep = _creepFactory.Create(creepType);
                newCreep.Position = _spawnPointsController.GetRandomSpawnPoint();
                newCreep.Init(_targetPosition);

                ServiceLocatorSingleton.Instance.GetService<IEventService>().CreepSpawned(newCreep);
            }

            _isSpawning = false;
        }
    }
}
