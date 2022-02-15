namespace TowerDefense
{
    public interface ITurretFactory
    {
        public Turret Create(Turret.EType type);
    }
}