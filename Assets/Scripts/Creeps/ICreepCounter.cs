namespace TowerDefense
{
    public interface ICreepCounter
    {
        public int GetNumCreepsRemaining();

        public int GetNumCreepsEliminated();

        public int GetNumTotalCreeps();

        public bool AreCreepsRemaining();

        public void IncreaseCreepsRemaining();

        public void DecreaseCreepsRemaining();
    }
}
