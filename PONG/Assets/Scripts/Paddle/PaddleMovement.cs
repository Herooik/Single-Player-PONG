using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var clamPosY = Mathf.Clamp(mousePosition.y, -4, 4);
        var newPaddlePos = new Vector2(transform.position.x, clamPosY);

        transform.position = newPaddlePos;
    }
}
