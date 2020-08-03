using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyZone : MonoBehaviour
{
    [SerializeField] private ChangeDirectionWall changeDirectionWall;
    [SerializeField] private PlayerLives playerLives;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallMovement>())
        {
            changeDirectionWall.IsWallTouched = false;
            playerLives.SubtractLife();
        }
    }
}
