using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class WavesController : IWavesController
    {
        private MultipleWavesConfigData _wavesConfigData;

        private ICreepWaveSpawner _creepWaveSpawner;

        private int _currentWaveIndex = 0;

        public WavesController(MultipleWavesConfigData wavesConfigData, ICreepWaveSpawner creepWaveSpawner)
        {
            _wavesConfigData = wavesConfigData;
            _creepWaveSpawner = creepWaveSpawner;
        }

        public int GetCurrentWaveNumber()
        {
            return _currentWaveIndex;
        }

        public int GetNumWaves()
        {
            return _wavesConfigData.Waves.Length;
        }

        public bool AreWavesRemaining()
        {
            return (GetCurrentWaveNumber() < GetNumWaves());
        }

        public void StartNextWave()
        {
            CreepWave creepWave = _wavesConfigData.GetCreepWave(_currentWaveIndex);
            _creepWaveSpawner.StartWaveSpawn(creepWave);

            _currentWaveIndex++;
        }
    }
}
