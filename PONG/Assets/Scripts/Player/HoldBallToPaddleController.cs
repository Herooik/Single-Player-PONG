using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBallToPaddleController : MonoBehaviour
{
    public bool isBallLaunched;
    
    [SerializeField] private GameObject ballPrefab;

    private Vector3 _distanceToBall;

    private void Start()
    {
        _distanceToBall = ballPrefab.transform.position - transform.position;
    }

    private void Update()
    {
        if (!isBallLaunched && GameManager.Instance.IsGameReady)
        {
            LockBallToPaddle();

            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        ballPrefab.transform.position = transform.position + _distanceToBall;
    }
    
    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBallLaunched = true;
            ballPrefab.GetComponent<BallMovement>().AddForceToBall();
        }
    }
}
