using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public bool IsStartMenuHide { get; private set; }

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameplayUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartGame()
    {
        IsStartMenuHide = true;
        startMenu.SetActive(false);
        gameplayUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void RefreshPlayerLivesText(int livesAmount)
    {
        livesText.text = "Lives: " + livesAmount + "x";
    }
    
    public void RefreshScoreText(int scoreAmount)
    {
        scoreText.text = scoreAmount.ToString();
    }

    public void UpdateHighScoreText(int highScore)
    {
        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    public void ShowEndGameCanvas()
    {
        Debug.LogError("UI END GAME");
    }

}
