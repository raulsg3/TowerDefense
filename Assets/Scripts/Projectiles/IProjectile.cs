using UnityEngine;

namespace TowerDefense
{
    public interface IProjectile
    {
        public void ShootAt(Vector3 targetPosition);
    }
}
