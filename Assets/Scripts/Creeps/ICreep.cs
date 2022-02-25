using UnityEngine;

namespace TowerDefense
{
    public interface ICreep
    {
        public enum EType
        {
            Normal,
            Heavy
        }

        ICreep.EType Type { get; }

        Vector3 Position { get; set; }

        float Damage { get; }

        int Reward { get; }

        void Init(Vector3 targetPosition);
    }
}