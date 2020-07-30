using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOnCollisionBehaviour : MonoBehaviour
{
    [SerializeField] private HoldBallToPaddleController _holdBallToPaddleController;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_holdBallToPaddleController.HasStarted)
        {
            ScoreManager.Instance.AddPoint();
        }
    }
}
