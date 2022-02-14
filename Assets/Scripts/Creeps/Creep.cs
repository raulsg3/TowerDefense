using UnityEngine;

namespace TowerDefense
{
    public class Creep : MonoBehaviour
    {
        public enum EType
        {
            Normal
        }

        [SerializeField]
        private EType _type;

        public EType Type => _type;

        [SerializeField]
        private TypeCreepsConfigData _typeCreepsConfigData;

        [SerializeField]
        private ICreepMovement _creepMovement;

        public void Init(Vector3 targetPosition)
        {
            _creepMovement.SetSpeed(_typeCreepsConfigData.Speed);
            _creepMovement.SetTarget(targetPosition);
        }
    }
}
