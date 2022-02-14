using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Level/SpawnPoints/Spawn Points Configuration Data", fileName = "SpawnPointsConfigData")]
    public class SpawnPointsConfigData : ScriptableObject
    {
        [SerializeField]
        private Vector3[] _spawnPoints;

        public Vector3[] SpawnPoints => _spawnPoints;
    }
}
