using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/PlayerStructures/Player Structures Configuration Data", fileName = "PlayerStructuresConfigData")]
    public class PlayerStructuresConfigData : ScriptableObject
    {
        [SerializeField]
        private float _baseHealth = 1f;

        public float BaseHealth => _baseHealth;
    }
}

