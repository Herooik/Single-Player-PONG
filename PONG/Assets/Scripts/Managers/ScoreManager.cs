using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int _score;
    private int _highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("High Score");
        _score = 0;
        
        UIManager.Instance.RefreshScoreText(_score);
        UIManager.Instance.UpdateHighScoreText(_highScore);
    }

    public void AddPoint()
    {
        _score++;
        UIManager.Instance.RefreshScoreText(_score);
    }

    public void CheckForHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("High Score", _highScore);
            UIManager.Instance.UpdateHighScoreText(_highScore);
        }
    }
}
