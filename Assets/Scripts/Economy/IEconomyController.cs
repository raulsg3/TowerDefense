namespace TowerDefense
{
    public interface IEconomyController
    {
        public int GetCoins();

        public void CollectCoins(ICreep creep);

        public bool SpendCoins(int coins);

        public void UpdateView();
    }
}
