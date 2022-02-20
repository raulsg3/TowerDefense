using System.Collections.Generic;

namespace TowerDefense
{
    public class CreepWave
    {
        private Creep.EType[] _creeps;

        private float _timeBetweenCreeps = 1f;

        public Creep.EType[] Creeps => _creeps;
        public float TimeBetweenCreeps => _timeBetweenCreeps;

        public CreepWave(Creep.EType[] creeps, float timeBetweenCreeps)
        {
            _creeps = creeps;
            _timeBetweenCreeps = timeBetweenCreeps;
        }
    }
}
