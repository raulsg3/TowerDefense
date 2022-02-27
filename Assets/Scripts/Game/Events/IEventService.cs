using System;
using UnityEngine;

namespace TowerDefense
{
    public interface IEventService
    {
        event Action OnPauseGame;
        event Action OnResumeGame;

        event Action OnPlayerBaseDestroyed;

        event Action<Turret.EType> OnTurretPlacingActivated;
        event Action OnTurretPlacingDeactivated;
        event Action<Vector3> OnTurretPositionChosen;

        event Action<ICreep> OnCreepSpawned;
        event Action<ICreep> OnCreepEliminated;
        event Action OnAllCreepsEliminated;

        void PauseGame();
        
        void ResumeGame();

        void PlayerBaseDestroyed();

        void ActivateTurretPlacing(Turret.EType turretType);

        void DeactivateTurretPlacing();

        void TurretPositionChosen(Vector3 position);

        void CreepSpawned(ICreep creep);

        void CreepEliminated(ICreep creep);

        void AllCreepsEliminated();
    }
}