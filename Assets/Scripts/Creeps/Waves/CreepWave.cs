using System.Collections.Generic;

namespace TowerDefense
{
    public class CreepWave
    {
        private ICreep.EType[] _creeps;

        private float _timeBetweenCreeps = 1f;

        public ICreep.EType[] Creeps => _creeps;
        public float TimeBetweenCreeps => _timeBetweenCreeps;

        public CreepWave(ICreep.EType[] creeps, float timeBetweenCreeps)
        {
            _creeps = creeps;
            _timeBetweenCreeps = timeBetweenCreeps;
        }
    }
}
