using UnityEngine;

namespace TowerDefense
{
    public class Creep : MonoBehaviour, ICreep
    {
        [SerializeField]
        private ICreep.EType _type;

        [SerializeField]
        private TypeCreepsConfigData _typeCreepsConfigData;

        [SerializeField]
        private ICreepMovement _creepMovement;

        [SerializeField]
        private Health _creepHealth;

        public ICreep.EType Type => _type;

        public float Damage => _typeCreepsConfigData.Damage;

        public int Reward => _typeCreepsConfigData.Reward;

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public void Init(Vector3 targetPosition)
        {
            _creepMovement.SetSpeed(_typeCreepsConfigData.Speed);
            _creepMovement.SetTarget(targetPosition);

            _creepHealth.SetHealth(_typeCreepsConfigData.Health);
        }
    }
}
