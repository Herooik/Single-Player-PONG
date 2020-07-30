using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private float movementSpeed = 3f;

    private Vector2 _lastVelocity;
    
    private void Start()
    {
        AddForceToBall();
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
        _lastVelocity = ballRigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ChangeDirectionWall>())
        {
            ChangeBounceDirection();
            return;
        }

        BounceOfTheWall(Vector2.Reflect(_lastVelocity.normalized, other.contacts[0].normal));
    }

    private void ChangeBounceDirection()
    {
        var yPos = Random.Range(-1f, 1f);
        var xPos = Random.Range(-1, -0.5f);

        BounceOfTheWall(new Vector2(xPos, Random.value));
    }

    private void BounceOfTheWall(Vector2 setDirection)
    {
        var speed = _lastVelocity.magnitude;

        var direction = setDirection;

        ballRigidbody.velocity = direction * speed;
    }
}
