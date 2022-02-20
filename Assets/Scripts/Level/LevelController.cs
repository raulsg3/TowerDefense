using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        private MultipleWavesConfigData _multipleWavesConfigData;

        private IWavesController _wavesController;

        private UIController _uiController;

        private void OnEnable()
        {
            EventManagerSingleton.Instance.OnPauseGame += PauseLevel;
            EventManagerSingleton.Instance.OnResumeGame += ResumeLevel;

            EventManagerSingleton.Instance.OnPlayerBaseDestroyed += PerformGameOver;
        }

        private void OnDisable()
        {
            EventManagerSingleton.Instance.OnPauseGame -= PauseLevel;
            EventManagerSingleton.Instance.OnResumeGame -= ResumeLevel;

            EventManagerSingleton.Instance.OnPlayerBaseDestroyed -= PerformGameOver;
        }

        public void Init(UIController uiController, MultipleWavesConfigData multipleWavesConfigDataInstance,
            IWavesController wavesController)
        {
            _uiController = uiController;
            _multipleWavesConfigData = multipleWavesConfigDataInstance;
            _wavesController = wavesController;
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
            WaitForSeconds waitCurrentWaveSpawning = new WaitForSeconds(0.5f);

            yield return initialWait;

            StartNextWave();

            while (_wavesController.AreWavesRemaining())
            {
                if (!_wavesController.IsCurrentWaveSpawning())
                {
                    yield return waitBetweenWaves;
                    StartNextWave();
                }
                else
                {
                    yield return waitCurrentWaveSpawning;
                }
            }

            EventManagerSingleton.Instance.OnAllCreepsEliminated += HandleAllCreepsEliminated;
        }

        private void StartNextWave()
        {
            _wavesController.StartNextWave();
            UpdateHudUI();
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

        private void HandleAllCreepsEliminated()
        {
            if (!_wavesController.AreWavesRemaining() && !_wavesController.IsCurrentWaveSpawning())
            {
                EventManagerSingleton.Instance.OnAllCreepsEliminated -= HandleAllCreepsEliminated;
                PerformGameCompleted();
            }
        }
    }
}
