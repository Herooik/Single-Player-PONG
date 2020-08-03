using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed { get; set; }

    [SerializeField] private float startingMovementSpeed = 20f;
    [SerializeField] private Rigidbody2D ballRigidbody;

    private void Awake()
    {
        SetStartMovementSpeed();
    }

    public void SetStartMovementSpeed()
    {
        movementSpeed = startingMovementSpeed;
    }

    public void AddForceToBall()
    {
        var xPos = Random.Range(0.5f, 1);
        var yPos = Random.Range(-0.5f, 0.5f);
        
        ballRigidbody.AddForce(new Vector2(xPos, yPos));
    }

    private void FixedUpdate()
    {
        BallMoving();
    }

    private void BallMoving()
    {
        ballRigidbody.velocity = ballRigidbody.velocity.normalized * movementSpeed;
    }
}
