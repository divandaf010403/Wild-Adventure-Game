using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f; // The speed at which the character moves

    private bool moveRight = true; // Flag to determine if the character should move right

    private void Start()
    {
        MoveRoutine();
    }

    private void Update()
    {
        
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (moveRight)
            {
                MoveRight();
                yield return new WaitForSeconds(3f);
            }
            else
            {
                MoveLeft();
                yield return new WaitForSeconds(3f);
            }
            moveRight = !moveRight;
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
