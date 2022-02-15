namespace TowerDefense
{
    public class TurretHealth : PlayerStructureHealth
    {
        public override void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
