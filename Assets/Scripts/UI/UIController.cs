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

        [Header("Panels")]
        [SerializeField]
        private RectTransform _gameOverPanel = null;

        [SerializeField]
        private RectTransform _gameCompletedPanel = null;

        public void UpdateWavesCount(int currentWave, int numWaves)
        {
            _wavesCountText.text = currentWave.ToString() + " / " + numWaves.ToString();
        }

        public void HandleBulletTurretButton()
        {
            EventManagerSingleton.Instance.ActivateTurretPlacing(Turret.EType.Bullets);
        }

        public void ShowGameOver()
        {
            _gameOverPanel.gameObject.SetActive(true);
            EventManagerSingleton.Instance.PauseGame();
        }

        public void ShowGameCompleted()
        {
            _gameCompletedPanel.gameObject.SetActive(true);
            EventManagerSingleton.Instance.PauseGame();
        }

        public void HandleRestartButton()
        {
            EventManagerSingleton.Instance.ResumeGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Scenes.MainScene);
        }

        public void HandleExitButton()
        {
            Application.Quit();
        }
    }
}
