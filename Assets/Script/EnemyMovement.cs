using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    Rigidbody2D enemyRb;
    BoxCollider2D enemyCol;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isFacingRight())
        {
            enemyRb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            enemyRb.velocity = new Vector2(speed, 0f);
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRb.velocity.x)), transform.localScale.y);
    }
}
