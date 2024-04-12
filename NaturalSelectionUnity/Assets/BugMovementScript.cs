using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovementScript : MonoBehaviour
{
    public GameState gameState; // Reference to the GameState script
    public float linearSpeed = 5f; // Speed for linear movement
    public float randomSpeedRange = 5f; // Range for random movement speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameState.isRandomSelected)
        {
            SetRandomMovement();
        }
        else
        {
            SetLinearMovement();
        }
    }

    void SetLinearMovement()
    {
        // Set linear velocity for the bug
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * gameState.speed;
    }

    void SetRandomMovement()
    {
        StartCoroutine(RandomMovementCoroutine());
    }

    IEnumerator RandomMovementCoroutine()
    {
        while (true)
        {
            // Calculate random velocity within a range
            
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.velocity = randomDirection * gameState.speed;

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Reverse direction
            rb.velocity *= -1;
        }
    }

}

