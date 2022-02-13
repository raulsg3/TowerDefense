using System.Collections.Generic;

namespace TowerDefense
{
    public class CreepWave
    {
        private Dictionary<Creep.EType, int> _numCreepsByType;

        private float _timeBetweenCreeps = 1f;

        public Dictionary<Creep.EType, int> NumCreepsByType => _numCreepsByType;
        public float TimeBetweenCreeps => _timeBetweenCreeps;

        public CreepWave(Dictionary<Creep.EType, int> numCreepsByType, float timeBetweenCreeps)
        {
            _numCreepsByType = numCreepsByType;
            _timeBetweenCreeps = timeBetweenCreeps;
        }
    }
}
