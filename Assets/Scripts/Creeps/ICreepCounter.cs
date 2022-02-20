namespace TowerDefense
{
    public interface ICreepCounter
    {
        public int GetNumCreepsRemaining();

        public int GetNumCreepsEliminated();

        public int GetNumTotalCreeps();

        public bool AreCreepsRemaining();

        public void IncreaseCreepsRemaining(Creep creep);

        public void DecreaseCreepsRemaining(Creep creep);
    }
}
