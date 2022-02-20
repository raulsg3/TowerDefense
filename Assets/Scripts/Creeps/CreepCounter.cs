namespace TowerDefense
{
    public class CreepCounter : ICreepCounter
    {
        private int _numRemainingCreeps = 0;
        private int _numEliminatedCreeps = 0;

        public CreepCounter()
        {
            EventManagerSingleton.Instance.OnCreepSpawned += HandleCreepSpawned;
            EventManagerSingleton.Instance.OnCreepEliminated += HandleCreepEliminated;
        }

        ~CreepCounter()
        {
            EventManagerSingleton.Instance.OnCreepSpawned -= HandleCreepSpawned;
            EventManagerSingleton.Instance.OnCreepEliminated -= HandleCreepEliminated;
        }

        public int GetNumCreepsRemaining()
        {
            return _numRemainingCreeps;
        }

        public int GetNumCreepsEliminated()
        {
            return _numEliminatedCreeps;
        }

        public int GetNumTotalCreeps()
        {
            return _numRemainingCreeps + _numEliminatedCreeps;
        }

        public bool AreCreepsRemaining()
        {
            return (_numRemainingCreeps > 0);
        }

        private void HandleCreepSpawned()
        {
            _numRemainingCreeps++;
        }

        private void HandleCreepEliminated()
        {
            _numRemainingCreeps--;
            _numEliminatedCreeps++;

            if (!AreCreepsRemaining())
                EventManagerSingleton.Instance.AllCreepsEliminated();
        }
    }
}
