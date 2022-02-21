using UnityEngine;

namespace TowerDefense
{
    public class Creep : MonoBehaviour
    {
        public enum EType
        {
            Normal,
            Heavy
        }

        [SerializeField]
        private EType _type;

        [SerializeField]
        private TypeCreepsConfigData _typeCreepsConfigData;

        [SerializeField]
        private ICreepMovement _creepMovement;

        [SerializeField]
        private Health _creepHealth;

        public EType Type => _type;

        public float Damage => _typeCreepsConfigData.Damage;

        public int Reward => _typeCreepsConfigData.Reward;

        public void Init(Vector3 targetPosition)
        {
            _creepMovement.SetSpeed(_typeCreepsConfigData.Speed);
            _creepMovement.SetTarget(targetPosition);

            _creepHealth.SetHealth(_typeCreepsConfigData.Health);
        }
    }
}
