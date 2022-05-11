using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    

    BrickHolder brickHolder;

    private void OnEnable()
    {
        brickHolder = FindObjectOfType<BrickHolder>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleHitByBallEvent();
        }
    }

    private void HandleHitByBallEvent()
    {

        brickHolder.DecrementBrickCount(1);
        Destroy(gameObject);
    }
}
