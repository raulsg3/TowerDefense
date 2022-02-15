using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/PlayerBase/Player Base Configuration Data", fileName = "PlayerBaseConfigData")]
    public class PlayerBaseConfigData : ScriptableObject
    {
        [SerializeField]
        private float _health = 1f;

        public float Health => _health;
    }
}

