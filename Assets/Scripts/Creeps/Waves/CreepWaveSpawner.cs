using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepWaveSpawner : ICreepWaveSpawner
    {
        [SerializeField]
        private CreepWaveConfigData _creepWaveConfigData;

        private CreepWaveConfigData _creepWaveConfigDataInstance;

        [SerializeField]
        private CreepFactoryConfigData _creepFactoryConfigData;

        private ICreepFactory _creepFactory;

        public CreepWaveSpawner(ICreepFactory creepFactory)
        {
            _creepFactory = creepFactory;
        }

        void Start()
        {
            _creepWaveConfigDataInstance = Instantiate(_creepWaveConfigData);
            _creepFactory = new CreepFactory(Instantiate(_creepFactoryConfigData));
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CreepWave creepWave = _creepWaveConfigDataInstance.GetCreepWave();
                StartWaveSpawn(creepWave);
            }
        }

        public override void StartWaveSpawn(CreepWave creepWave)
        {
            StartCoroutine(SpawnWave(creepWave));
        }

        private IEnumerator SpawnWave(CreepWave creepWave)
        {
            WaitForSeconds waitBetweenCreeps = new WaitForSeconds(_creepWaveConfigDataInstance.TimeBetweenCreeps);

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
