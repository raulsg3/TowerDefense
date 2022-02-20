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

        public event Action OnPauseGame;

        public void PauseGame()
        {
            OnPauseGame?.Invoke();
        }

        public event Action OnResumeGame;

        public void ResumeGame()
        {
            OnResumeGame?.Invoke();
        }

        public event Action OnPlayerBaseDestroyed;

        public void PlayerBaseDestroyed()
        {
            OnPlayerBaseDestroyed?.Invoke();
        }

        public event Action OnTurretPlacingActivated;

        public void ActivateTurretPlacing()
        {
            OnTurretPlacingActivated?.Invoke();
        }

        public event Action OnTurretPlacingDeactivated;

        public void DeactivateTurretPlacing()
        {
            OnTurretPlacingDeactivated?.Invoke();
        }

        public event Action<Vector3> OnTurretPositionChosen;

        public void TurretPositionChosen(Vector3 position)
        {
            OnTurretPositionChosen?.Invoke(position);
        }

        public event Action OnCreepSpawned;

        public void CreepSpawned()
        {
            OnCreepSpawned?.Invoke();
        }

        public event Action OnCreepEliminated;

        public void CreepEliminated()
        {
            OnCreepEliminated?.Invoke();
        }

        public event Action OnAllCreepsEliminated;

        public void AllCreepsEliminated()
        {
            OnAllCreepsEliminated?.Invoke();
        }
    }
}
