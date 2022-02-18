using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _gameOverPanel = null;

    [SerializeField]
    private RectTransform _gameCompletedPanel = null;

    public void ShowGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }

    public void ShowGameCompleted()
    {
        _gameCompletedPanel.gameObject.SetActive(true);
    }
}
