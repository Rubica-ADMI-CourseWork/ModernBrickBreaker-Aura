
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{

    [SerializeField] int brickHitPoints;
    [SerializeField] GameObject hitFX;
    private int BrickHitPoints
    {
        get => brickHitPoints;
        set
        {
            brickHitPoints = value;
            if(brickHitPoints <= 0)
            {
                HandleBrickDestructionEvent();
            }
        }
    }
    BrickHolder brickHolder;

    private void OnEnable()
    {
        brickHolder = FindObjectOfType<BrickHolder>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleBrickHitEvent();
        }
    }

    public void HandleBrickDestructionEvent()
    {

        brickHolder.DecrementBrickCount(1);
        Destroy(gameObject);
    }

    private void HandleBrickHitEvent()
    {
        Debug.Log("I've been Hit!");
        BrickHitPoints--;
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,2),Random.Range(0,2),Random.Range(0,2),1);
        Instantiate(hitFX,transform.position,Quaternion.identity);
    }

}
