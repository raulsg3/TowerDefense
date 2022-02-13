using System.Collections.Generic;

namespace TowerDefense
{
    public class CreepWave
    {
        private Dictionary<Creep.EType, int> _numCreepsByType;

        public Dictionary<Creep.EType, int> NumCreepsByType => _numCreepsByType;

        public CreepWave(Dictionary<Creep.EType, int> numCreepsByType)
        {
            _numCreepsByType = numCreepsByType;
        }
    }
}
