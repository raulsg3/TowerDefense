using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        private MultipleWavesConfigData _multipleWavesConfigData;

        private IWavesController _wavesController;
        private IPlaceTurretController _turretController;

        private UIController _uiController;

        private void OnEnable()
        {
            EventManagerSingleton.Instance.OnPlayerBaseDestroyed += PerformGameOver;
            EventManagerSingleton.Instance.OnTurretPositionChosen += TryPlaceTurret;
        }

        private void OnDisable()
        {
            EventManagerSingleton.Instance.OnPlayerBaseDestroyed -= PerformGameOver;
            EventManagerSingleton.Instance.OnTurretPositionChosen -= TryPlaceTurret;
        }

        public void Init(UIController uiController, MultipleWavesConfigData multipleWavesConfigDataInstance,
            IWavesController wavesController, IPlaceTurretController turretController)
        {
            _uiController = uiController;
            _multipleWavesConfigData = multipleWavesConfigDataInstance;
            _wavesController = wavesController;
            _turretController = turretController;
        }

        public void StartLevel()
        {
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
                yield return waitBetweenWaves;
            }

            PerformGameCompleted();
        }

        private void PauseLevel()
        {
            Time.timeScale = 0;
        }

        private void PerformGameOver()
        {
            _uiController.ShowGameOver();
            PauseLevel();
        }

        private void PerformGameCompleted()
        {
            _uiController.ShowGameCompleted();
            PauseLevel();
        }

        private void TryPlaceTurret(Vector3 turretPosition)
        {
            bool turretPlaced = _turretController.PlaceTurret(turretPosition);

            if (turretPlaced)
                EventManagerSingleton.Instance.DeactivateTurretPlacing();
        }
    }
}
