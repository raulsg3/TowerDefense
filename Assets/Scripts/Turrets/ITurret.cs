namespace TowerDefense
{
    public interface ITurret
    {
        public int GetPrice();

        public float GetHealth();

        public float GetCooldownTime();

        public bool CanPerformAction();

        public void PerformAction();

        public void WaitUntilCanPerformAction();
    }
}
