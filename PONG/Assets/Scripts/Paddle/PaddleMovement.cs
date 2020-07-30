using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newPaddlePos = new Vector2(transform.position.x, mousePosition.y);
        transform.position = newPaddlePos;
        //transform.position = Vector2.Lerp(transform.position, newPaddlePos, 0.5f);
    }
}
