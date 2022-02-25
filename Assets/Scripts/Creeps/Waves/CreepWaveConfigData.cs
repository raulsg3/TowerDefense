using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Waves/Creep Wave Configuration Data", fileName = "CreepWaveConfigData")]
    public class CreepWaveConfigData : ScriptableObject
    {
        [SerializeField]
        private float _timeBetweenCreeps = 1f;

        [SerializeField]
        private ICreep.EType[] _waveCreeps;

        public CreepWave GetCreepWave()
        {
            return new CreepWave(_waveCreeps, _timeBetweenCreeps);
        }
    }
}
