namespace TowerDefense
{
    public class CreepCounter : ICreepCounter
    {
        private int _numRemainingCreeps = 0;
        private int _numEliminatedCreeps = 0;

        public CreepCounter()
        {
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

        public void IncreaseCreepsRemaining()
        {
            _numRemainingCreeps++;
        }

        public void DecreaseCreepsRemaining()
        {
            _numRemainingCreeps--;
            _numEliminatedCreeps++;

            if (!AreCreepsRemaining())
                EventManagerSingleton.Instance.AllCreepsEliminated();
        }
    }
}
