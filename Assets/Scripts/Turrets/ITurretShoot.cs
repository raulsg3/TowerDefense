namespace TowerDefense
{
    public interface ITurretShoot
    {
        public bool CanShoot();

        public void ShootTarget();

        public void WaitUntilCanShoot();
    }
}
