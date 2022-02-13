using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Factory/Creep Wave Configuration Data", fileName = "CreepWaveConfigData")]
    public class CreepWaveConfigData : ScriptableObject
    {
        [SerializeField]
        private float _timeBetweenCreeps = 1f;

        public float TimeBetweenCreeps => _timeBetweenCreeps;

        [SerializeField]
        private Creep.EType[] _waveCreeps;

        private Dictionary<Creep.EType, int> _waveCreepsByType;

        void Awake()
        {
            _waveCreepsByType = new Dictionary<Creep.EType, int>();

            foreach (Creep.EType creep in _waveCreeps)
            {
                _waveCreepsByType.TryGetValue(creep, out var currentCreeps);
                _waveCreepsByType[creep] = currentCreeps + 1;
            }
        }

        public CreepWave GetCreepWave()
        {
            return new CreepWave(_waveCreepsByType);
        }
    }
}
