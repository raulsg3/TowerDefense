using UnityEngine;

namespace TowerDefense
{
    public class SpawnPointsController : ISpawnPointsController
    {
        private SpawnPointsConfigData _spawnPointsConfigData;

        public SpawnPointsController(SpawnPointsConfigData spawnPointsConfigData)
        {
            _spawnPointsConfigData = spawnPointsConfigData;
        }

        public int GetNumSpawnPoints()
        {
            return _spawnPointsConfigData.SpawnPoints.Length;
        }

        public Vector3 GetRandomSpawnPoint()
        {
            if (GetNumSpawnPoints() == 0)
                throw new System.Exception($"No spawn points defined");

            return GetSpawnPoint(Random.Range(0, GetNumSpawnPoints() - 1));
        }

        public Vector3 GetSpawnPoint(int spawnPointIndex)
        {
            return _spawnPointsConfigData.SpawnPoints[spawnPointIndex];
        }
    }
}
