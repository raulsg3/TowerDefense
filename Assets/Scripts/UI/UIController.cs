using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class UIController : MonoBehaviour
    {
        [Header("Hud")]
        [SerializeField]
        private Text _wavesCountText = null;

        [SerializeField]
        private Text _coinsCountText = null;

        [SerializeField]
        private Button _bulletTurretButton = null;

        [Header("Panels")]
        [SerializeField]
        private RectTransform _gameOverPanel = null;

        [SerializeField]
        private RectTransform _gameCompletedPanel = null;

        public void UpdateWavesCount(int currentWave, int numWaves)
        {
            _wavesCountText.text = currentWave.ToString() + " / " + numWaves.ToString();
        }

        public void UpdateCoinsCount(int coins)
        {
            _coinsCountText.text = coins.ToString();
        }

        public void HandleBulletTurretButton()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().ActivateTurretPlacing(Turret.EType.Bullets);
        }

        public void ShowGameOver()
        {
            ShowEndGamePanel(_gameOverPanel);
        }

        public void ShowGameCompleted()
        {
            ShowEndGamePanel(_gameCompletedPanel);
        }

        private void ShowEndGamePanel(RectTransform panel)
        {
            DeactivateButtons();

            panel.gameObject.SetActive(true);
            ServiceLocatorSingleton.Instance.GetService<IEventService>().PauseGame();
        }

        private void DeactivateButtons()
        {
            _bulletTurretButton.interactable = false;
        }

        public void HandleRestartButton()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().ResumeGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Scenes.MainScene);
        }

        public void HandleExitButton()
        {
            Application.Quit();
        }
    }
}
