using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Factory/Multiple Wave Configuration Data", fileName = "MultiWaveConfigData")]
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

        public CreepWaveConfigData[] Waves => _waves;

        public CreepWave GetCreepWave(int waveIndex)
        {
            if (waveIndex >= _waves.Length)
                throw new Exception($"Wave index {waveIndex} out of range");

            return _waves[waveIndex].GetCreepWave();
        }
    }
}
