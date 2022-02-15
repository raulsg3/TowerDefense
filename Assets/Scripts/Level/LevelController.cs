﻿using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        private MultipleWavesConfigData _multipleWavesConfigData;

        private IWavesController _wavesController;
        private ITurretController _turretController;

        private void OnEnable()
        {
            EventManagerSingleton.Instance.OnPlayerBaseDestroyed += EndGame;
            EventManagerSingleton.Instance.OnTurretPositionChosen += TryPlaceTurret;
        }

        private void OnDisable()
        {
            EventManagerSingleton.Instance.OnPlayerBaseDestroyed -= EndGame;
            EventManagerSingleton.Instance.OnTurretPositionChosen -= TryPlaceTurret;
        }

        public void Init(MultipleWavesConfigData multipleWavesConfigDataInstance, IWavesController wavesController,
            ITurretController turretController)
        {
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
        }

        private void EndGame()
        {
            Debug.Log("GAME OVER");
        }

        private void TryPlaceTurret(Vector3 turretPosition)
        {
            bool turretPlaced = _turretController.PlaceTurret(turretPosition);

            if (turretPlaced)
                EventManagerSingleton.Instance.SetTurretPlacing(false);
        }
    }
}
