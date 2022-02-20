namespace TowerDefense
{
    public class EconomyController : IEconomyController
    {
        private Money _money = null;

        private UIController _uiController = null;

        public EconomyController(Money money, UIController uiController)
        {
            _money = money;

            _uiController = uiController;
            UpdateView();
        }

        public int GetCoins()
        {
            return _money.Coins;
        }

        public void CollectCoins(Creep creep)
        {
            _money.IncreaseCoins(creep.Reward);
            UpdateView();
        }

        public bool SpendCoins(int coins)
        {
            bool areEnoughCoins = (_money.Coins >= coins);

            if (areEnoughCoins)
            {
                _money.DecreaseCoins(coins);
                UpdateView();
            }

            return areEnoughCoins;
        }

        public void UpdateView()
        {
            _uiController.UpdateCoinsCount(_money.Coins);
        }
    }
}
