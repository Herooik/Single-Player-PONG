using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] [Range(0, 8)] private float maxPos = 4;
    [SerializeField] [Range(-8, 0)] private float minPos = -4;
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var clamPosY = Mathf.Clamp(mousePosition.y, minPos, maxPos);
        var newPaddlePos = new Vector2(transform.position.x, clamPosY);

        transform.position = newPaddlePos;
    }
}
