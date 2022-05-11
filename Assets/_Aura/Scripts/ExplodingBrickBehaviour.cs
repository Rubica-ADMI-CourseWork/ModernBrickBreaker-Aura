using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBrickBehaviour : MonoBehaviour
{
    [SerializeField] float radiusOfBlast;
    [SerializeField] GameObject xplosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Explode();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfBlast);
    }

    private void Explode()
    {
       
        RaycastHit2D[] hitInfo;
        hitInfo = Physics2D.CircleCastAll(transform.position, radiusOfBlast, new Vector2(0f, 0f));
        if(hitInfo.Length > 0)
        {
            foreach (var brick in hitInfo)
            {
                if (brick.collider.gameObject.CompareTag("BrickRegular"))
                {
                    brick.collider.GetComponent<BrickBehaviour>().HandleBrickDestructionEvent();
                }
            }
        }
        var xplosionFX = Instantiate(xplosionEffect, transform.position,Quaternion.identity);
        Destroy(gameObject, .01f);
        Destroy(xplosionFX, .2f);


    }
}
