using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        private MultipleWavesConfigData _multipleWavesConfigData;

        private IWavesController _wavesController;
        private IPlaceTurretController _placeTurretController;
        private ICreepCounter _creepCounter;

        private UIController _uiController;

        private void OnEnable()
        {
            EventManagerSingleton.Instance.OnPauseGame += PauseLevel;
            EventManagerSingleton.Instance.OnResumeGame += ResumeLevel;

            EventManagerSingleton.Instance.OnPlayerBaseDestroyed += PerformGameOver;
            EventManagerSingleton.Instance.OnTurretPositionChosen += TryPlaceTurret;
        }

        private void OnDisable()
        {
            EventManagerSingleton.Instance.OnPauseGame -= PauseLevel;
            EventManagerSingleton.Instance.OnResumeGame -= ResumeLevel;

            EventManagerSingleton.Instance.OnPlayerBaseDestroyed -= PerformGameOver;
            EventManagerSingleton.Instance.OnTurretPositionChosen -= TryPlaceTurret;
        }

        public void Init(UIController uiController, ICreepCounter creepCounter, MultipleWavesConfigData multipleWavesConfigDataInstance,
            IWavesController wavesController, IPlaceTurretController turretController)
        {
            _uiController = uiController;
            _creepCounter = creepCounter;
            _multipleWavesConfigData = multipleWavesConfigDataInstance;
            _wavesController = wavesController;
            _placeTurretController = turretController;
        }

        public void StartLevel()
        {
            UpdateHudUI();
            StartCoroutine(PlayLevel());
        }

        private IEnumerator PlayLevel()
        {
            WaitForSeconds initialWait = new WaitForSeconds(_multipleWavesConfigData.InitialWaitingTime);
            WaitForSeconds waitBetweenWaves = new WaitForSeconds(_multipleWavesConfigData.TimeBetweenWaves);

            yield return initialWait;

            while (_wavesController.AreWavesRemaining())
            {
                _wavesController.StartNextWave();
                UpdateHudUI();

                if (_wavesController.AreWavesRemaining())
                    yield return waitBetweenWaves;
            }

            EventManagerSingleton.Instance.OnAllCreepsEliminated += HandleAllCreepsEliminated;
        }

        private void PauseLevel()
        {
            Time.timeScale = 0;
        }

        private void ResumeLevel()
        {
            Time.timeScale = 1f;
        }

        private void UpdateHudUI()
        {
            _uiController.UpdateWavesCount(_wavesController.GetCurrentWaveNumber(), _wavesController.GetNumWaves());
        }

        private void PerformGameOver()
        {
            _uiController.ShowGameOver();
        }

        private void PerformGameCompleted()
        {
            _uiController.ShowGameCompleted();
        }

        private void TryPlaceTurret(Vector3 turretPosition)
        {
            bool turretPlaced = _placeTurretController.PlaceTurret(turretPosition);

            if (turretPlaced)
                EventManagerSingleton.Instance.DeactivateTurretPlacing();
        }

        private void HandleAllCreepsEliminated()
        {
            if (!_wavesController.AreWavesRemaining())
            {
                EventManagerSingleton.Instance.OnAllCreepsEliminated -= HandleAllCreepsEliminated;
                PerformGameCompleted();
            }
        }
    }
}
