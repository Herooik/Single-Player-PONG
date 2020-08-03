using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameReady { get; private set; }

    [SerializeField] private PlayerLives _playerLives;
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private PlayAudioSystem _playAudioSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ResetGameStatistic()
    {
        _ballMovement.SetStartMovementSpeed();
        _playerLives.ResetLives();
        ScoreManager.Instance.ResetScore();

        IsGameReady = true;
    }

    public void GameEnd()
    {
        _playAudioSystem.PlayAudio();
        IsGameReady = false;
    }
}
