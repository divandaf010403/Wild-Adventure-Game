using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the enemy moves
    public float movementDuration = 3f; // Time it takes for the enemy to move in one direction

    public Rigidbody rb;
    private float timer;
    private bool isMovingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = movementDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Change direction
            isMovingRight = !isMovingRight;
            timer = movementDuration;
        }

        // Calculate movement vector
        Vector3 movement = isMovingRight ? Vector3.right : Vector3.left;
        movement *= moveSpeed * Time.deltaTime;

        // Apply movement to the enemy
        rb.MovePosition(transform.position + movement);
    }
}
