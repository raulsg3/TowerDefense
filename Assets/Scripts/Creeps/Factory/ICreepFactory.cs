namespace TowerDefense
{
    public interface ICreepFactory
    {
        public ICreep Create(ICreep.EType type);
    }
}