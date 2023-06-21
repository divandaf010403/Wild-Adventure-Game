using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;    // Speed at which the enemy moves
    public float leftBound;         // Left boundary position
    public float rightBound;        // Right boundary position

    private bool movingRight = true; // Flag to track the direction of movement

    void Update()
    {
        // Calculate the enemy's new position
        Vector3 newPosition = transform.position + (movingRight ? Vector3.right : Vector3.left) * moveSpeed * Time.deltaTime;

        // Check if the enemy has reached the boundary, then change direction
        if (newPosition.x >= rightBound)
        {
            movingRight = false;
        }
        else if (newPosition.x <= leftBound)
        {
            movingRight = true;
        }

        // Update the enemy's position
        transform.position = newPosition;
    }
}
