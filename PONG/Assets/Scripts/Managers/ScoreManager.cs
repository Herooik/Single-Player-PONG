using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
        
        ResetScore();
    }
    
    public void ResetScore()
    {
        _score = 0;

        UIManager.Instance.RefreshScoreText(_score);
    }

    public void CheckForHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("High Score", _highScore);
            UIManager.Instance.ShowEndMenu(_score, true);
        }
        else
        {
            UIManager.Instance.ShowEndMenu(_score, false);
        }

        ResetScore();
    }
    
    public void AddPoint()
    {
        _score++;
        UIManager.Instance.RefreshScoreText(_score);
    }
}
