using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private HoldBallToPaddleController _holdBallToPaddleController;
    
    private int _lives;

    private void Start()
    {
        ResetLives();
    }
    
    private void ResetLives()
    {
        _lives = maxLives;
        UIManager.Instance.RefreshPlayerLivesText(_lives);
    }

    public void SubtractLife()
    {
        _lives--;

        UIManager.Instance.RefreshPlayerLivesText(_lives);
        
        _holdBallToPaddleController.HasStarted = false;
        
        // play some sad sound, then
        // play some animation about losing life to inform player and after animation end

        if (_lives <= 0)
        {
            ResetLives();

            GameManager.Instance.GameEnd();
            
            ScoreManager.Instance.CheckForHighScore();
        }
    }
}
