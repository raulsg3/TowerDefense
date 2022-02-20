using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _gameOverPanel = null;

        [SerializeField]
        private RectTransform _gameCompletedPanel = null;

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

        public void RestartButton()
        {
            EventManagerSingleton.Instance.ResumeGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Scenes.MainScene);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
