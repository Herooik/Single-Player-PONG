using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIAnimationManager _uiAnimationManager;
    
    [Header("Gameplay UI")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI gameplayScoreText;

    [Header("End Menu UI")] 
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _uiAnimationManager.ShowStartMenu();
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
    
    public void RefreshScoreText(int scoreValue)
    {
        gameplayScoreText.text = scoreValue.ToString();
    }

    public void ShowEndMenu(int scoreValue, bool isHighScore)
    {
        _uiAnimationManager.ShowEndMenu();

        var highScoreValue = PlayerPrefs.GetInt("High Score");
        
        if (isHighScore)
        {
            highScoreText.text = "NEW HIGH SCORE!";
        }
        else
        {
            endScoreText.text = "YOUR SCORE: \n" + scoreValue;
            highScoreText.text = "HIGH SCORE: \n" + highScoreValue;
        }
    }

}
