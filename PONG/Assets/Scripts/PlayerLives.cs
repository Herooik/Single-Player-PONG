using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    
    private int _lives;

    private void Start()
    {
        _lives = maxLives;
        
        UIManager.Instance.RefreshPlayerLivesText(_lives);
    }

    public void SubtractLife()
    {
        _lives--;

        UIManager.Instance.RefreshPlayerLivesText(_lives);
        
        GetComponent<HoldBallToPaddleController>().HasStarted = false;
        
        // play some sad sound, then
        // play some animation about losing life to inform player and after animation end
        // move ball back to paddle

        if (_lives <= 0)
        {
            UIManager.Instance.ShowEndGameCanvas();
            ScoreManager.Instance.CheckForHighScore();
        }
    }
}
