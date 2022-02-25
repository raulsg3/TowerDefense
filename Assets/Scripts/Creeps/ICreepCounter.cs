namespace TowerDefense
{
    public interface ICreepCounter
    {
        public int GetNumCreepsRemaining();

        public int GetNumCreepsEliminated();

        public int GetNumTotalCreeps();

        public bool AreCreepsRemaining();

        public void IncreaseCreepsRemaining(ICreep creep);

        public void DecreaseCreepsRemaining(ICreep creep);
    }
}
