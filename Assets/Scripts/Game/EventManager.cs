using System;
using UnityEngine;

namespace TowerDefense
{
    public class EventManagerSingleton
    {
        private static EventManagerSingleton _instance;

        public static EventManagerSingleton Instance => _instance ?? (_instance = new EventManagerSingleton());

        private EventManagerSingleton()
        {
        }

        public event Action OnPlayerBaseDestroyed;

        public void PlayerBaseDestroyed()
        {
            OnPlayerBaseDestroyed?.Invoke();
        }

        public event Action<bool> OnSetTurretPlacing;

        public void SetTurretPlacing(bool active)
        {
            OnSetTurretPlacing?.Invoke(active);
        }

        public event Action<Vector3> OnTurretPositionChosen;

        public void TurretPositionChosen(Vector3 position)
        {
            OnTurretPositionChosen?.Invoke(position);
        }
    }
}
