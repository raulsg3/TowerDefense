namespace TowerDefense
{
    public class Money
    {
        private int _coins = 0;

        public int Coins => _coins;

        public Money(int initialCoins)
        {
            _coins = initialCoins;
        }

        public void IncreaseCoins(int coins)
        {
            _coins += coins;
        }

        public void DecreaseCoins(int coins)
        {
            _coins -= coins;
        }
    }
}
