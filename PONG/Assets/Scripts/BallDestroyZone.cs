using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyZone : MonoBehaviour
{
    [SerializeField] private PlayerLives playerLives;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerLives.SubtractLife();
    }
}
