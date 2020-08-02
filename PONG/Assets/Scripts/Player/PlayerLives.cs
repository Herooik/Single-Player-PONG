using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private HoldBallToPaddleController _holdBallToPaddleController;
    [SerializeField] private PlayAudioSystem _playAudioSystem;
    
    private int _lives;

    public void ResetLives()
    {
        _lives = maxLives;
        UIManager.Instance.RefreshPlayerLivesText(_lives);
    }

    public void SubtractLife()
    {
        _lives--;

        UIManager.Instance.RefreshPlayerLivesText(_lives);
        
        _holdBallToPaddleController.isBallLaunched = false;

        if (_lives <= 0)
        {
            GameManager.Instance.GameEnd();
            
            ScoreManager.Instance.CheckForHighScore();
            
            return;
        }
        
        _playAudioSystem.PlayAudio();
    }
}
