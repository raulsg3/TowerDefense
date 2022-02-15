using UnityEngine;

namespace TowerDefense
{
    public abstract class Turret : MonoBehaviour
    {
        public enum EType
        {
            Bullets
        }

        [SerializeField]
        protected EType _type;

        [SerializeField]
        protected IHealth _turretHealth;

        public EType Type => _type;

        public abstract void Init();
    }
}
