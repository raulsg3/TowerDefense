using UnityEngine;

namespace TowerDefense
{
    public interface ISpawnPointsController
    {
        public int GetNumSpawnPoints();

        public Vector3 GetRandomSpawnPoint();

        public Vector3 GetSpawnPoint(int spawnPointIndex);
    }
}
