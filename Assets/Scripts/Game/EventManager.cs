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
    }
}
