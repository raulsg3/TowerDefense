namespace TowerDefense
{
    public interface ICreepFactory
    {
        public Creep Create(Creep.EType type);
    }
}