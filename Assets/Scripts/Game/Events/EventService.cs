using System;
using UnityEngine;

namespace TowerDefense
{
    public class EventService : IEventService
    {
        public EventService()
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

        public event Action<Turret.EType> OnTurretPlacingActivated;

        public void ActivateTurretPlacing(Turret.EType turretType)
        {
            OnTurretPlacingActivated?.Invoke(turretType);
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

        public event Action<ICreep> OnCreepSpawned;

        public void CreepSpawned(ICreep creep)
        {
            OnCreepSpawned?.Invoke(creep);
        }

        public event Action<ICreep> OnCreepEliminated;

        public void CreepEliminated(ICreep creep)
        {
            OnCreepEliminated?.Invoke(creep);
        }

        public event Action OnAllCreepsEliminated;

        public void AllCreepsEliminated()
        {
            OnAllCreepsEliminated?.Invoke();
        }
    }
}
