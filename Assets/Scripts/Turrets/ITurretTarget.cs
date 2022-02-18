using System.Collections;

namespace TowerDefense
{
    public interface ITurretTarget
    {
        public bool HasTarget();

        public IEnumerator SearchForTarget();

        public bool IsTargetAimed();

        public void AimTarget();
    }
}
