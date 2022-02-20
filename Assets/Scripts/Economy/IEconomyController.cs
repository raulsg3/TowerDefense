namespace TowerDefense
{
    public interface IEconomyController
    {
        public int GetCoins();

        public void CollectCoins(Creep creep);

        public bool SpendCoins(int coins);

        public void UpdateView();
    }
}
