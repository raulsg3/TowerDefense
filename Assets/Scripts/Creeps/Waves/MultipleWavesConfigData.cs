using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Waves/Multiple Wave Configuration Data", fileName = "MultiWaveConfigData")]
    public class MultipleWavesConfigData : ScriptableObject
    {
        [SerializeField]
        private float _initialWaitingTime = 5f;

        public float InitialWaitingTime => _initialWaitingTime;

        [SerializeField]
        private float _timeBetweenWaves = 10f;

        public float TimeBetweenWaves => _timeBetweenWaves;

        [SerializeField]
        private CreepWaveConfigData[] _waves;

        private CreepWaveConfigData[] _wavesInstances;

        public CreepWaveConfigData[] Waves => _waves;

        void Awake()
        {
            _wavesInstances = new CreepWaveConfigData[_waves.Length];

            for (int wave = 0; wave < _waves.Length; ++wave)
                _wavesInstances[wave] = Instantiate(_waves[wave]);
        }

        public CreepWave GetCreepWave(int waveIndex)
        {
            if (waveIndex >= _wavesInstances.Length)
                throw new Exception($"Wave index {waveIndex} out of range");

            return _wavesInstances[waveIndex].GetCreepWave();
        }
    }
}
