using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeDirectionWall : MonoBehaviour
{
    public bool IsWallTouched { get; set; }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        IsWallTouched = true;
    }
}
