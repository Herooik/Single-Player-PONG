using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOnCollisionBehaviour : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private ChangeDirectionWall _changeDirectionWall;

    private float _startBallSpeed;

    private void Start()
    {
        _startBallSpeed = _ballMovement.movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_changeDirectionWall.IsWallTouched)
        {
            _ballMovement.movementSpeed += _startBallSpeed / 100;
            
            ScoreManager.Instance.AddPoint();

            _changeDirectionWall.IsWallTouched = false;
        }
    }
}
