using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    [SerializeField] private HoldBallToPaddleController _holdBallToPaddleController;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private PlayAudioSystem playAudioSystem;

    private Vector2 _lastVelocity;

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
        if(!_holdBallToPaddleController.isBallLaunched) return;
        
        playAudioSystem.PlayAudio();
        
        if (other.gameObject.GetComponent<ChangeDirectionWall>())
        {
            ChangeBounceDirection(other);
            return;
        }

        BounceOfTheWall(Vector2.Reflect(_lastVelocity.normalized, other.contacts[0].normal), other);
    }

    private void ChangeBounceDirection(Collision2D other)
    {
        var yPos = Random.Range(-1f, 1f);
        var xPos = Random.Range(-1, -0.5f);

        BounceOfTheWall(new Vector2(xPos, yPos), other);
    }

    private void BounceOfTheWall(Vector2 setDirection, Collision2D other)
    {
        var speed = _lastVelocity.magnitude;

        var direction = setDirection;

        ballRigidbody.velocity = direction * speed;
    }
}
