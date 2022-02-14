using UnityEngine;

namespace TowerDefense
{
    public abstract class IHealthView : MonoBehaviour
    {
        public abstract void UpdateHealth(float value);
    }
}