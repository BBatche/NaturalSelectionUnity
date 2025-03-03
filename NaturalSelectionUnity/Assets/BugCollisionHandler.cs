using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugAlleleScript;
public class BugCollisionHandler : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bug collided with a border object
        if (collision.gameObject.CompareTag("Border"))
        {
            // Get the normal of the collision (direction the bug collided from)
            Vector2 collisionNormal = collision.contacts[0].normal;

            // Reflect the bug's velocity based on the collision normal
            ReflectBugVelocity(collisionNormal);
        }
        if (collision.gameObject.CompareTag("KillZone"))
        {
            gameState.killedByKillZone++;
            gameState.currentPop--;
            BugAlleleScript bugAlleleScript = GetComponent<BugAlleleScript>();
            if (bugAlleleScript != null)
            {
                AlleleType bugType = bugAlleleScript.getAlleleType();

                switch (bugType)
                {
                    case AlleleType.Dom:
                        gameState.currentDom--;
                        break;
                    case AlleleType.Mid:
                        gameState.currentMid--;
                        break;
                    case AlleleType.Rec:
                        gameState.currentRec--;
                        break;
                }
            }
            
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bounds"))
        {
            gameState.currentPop--;
            BugAlleleScript bugAlleleScript = GetComponent<BugAlleleScript>();
            if (bugAlleleScript != null)
            {
                AlleleType bugType = bugAlleleScript.getAlleleType();

                switch (bugType)
                {
                    case AlleleType.Dom:
                        gameState.currentDom--;
                        break;
                    case AlleleType.Mid:
                        gameState.currentMid--;
                        break;
                    case AlleleType.Rec:
                        gameState.currentRec--;
                        break;
                }
            }
            Destroy(gameObject);
        }
        
    }
    
    void ReflectBugVelocity(Vector2 collisionNormal)
    {
        // Get the bug's Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Reflect the bug's velocity based on the collision normal
        rb.velocity = Vector2.Reflect(rb.velocity, collisionNormal);

        transform.up = rb.velocity.normalized;
    }


}
