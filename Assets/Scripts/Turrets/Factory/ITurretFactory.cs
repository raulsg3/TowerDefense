namespace TowerDefense
{
    public interface ITurretFactory
    {
        public Turret Create(Turret.EType type);

        public int GetPrice(Turret.EType type);
    }
}