using UnityEngine;

namespace TowerDefense
{
    public abstract class Creep : MonoBehaviour
    {
        public enum EType
        {
            Normal
        }

        [SerializeField]
        private EType _type;

        public EType Type => _type;

        [SerializeField]
        private NormalCreepsConfigData _normalCreepsConfigData;

        [SerializeField]
        private CreepMovement _creepMovement;

        public void Init(Vector3 targetPosition)
        {
            _creepMovement.SetSpeed(_normalCreepsConfigData.Speed);
            _creepMovement.SetTarget(targetPosition);
        }
    }
}
