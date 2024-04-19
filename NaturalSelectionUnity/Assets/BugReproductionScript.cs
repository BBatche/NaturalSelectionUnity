using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugAlleleScript;
public class BugReproductionScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    public GameObject bugPrefabPurple;
    public GameObject bugPrefabGreen;
    public float reproductionCooldown = 1f; // Cooldown period for bug reproduction
    private float reproductionTimer = 0f; // Timer for tracking reproduction cooldown

    void Update()
    {
        // Update reproduction timer
        reproductionTimer += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bug"))
        {
            BugReproductionScript otherBug = collision.gameObject.GetComponent<BugReproductionScript>();

            // Check if both bugs are eligible for reproduction
            if (reproductionTimer >= reproductionCooldown && otherBug.reproductionTimer >= otherBug.reproductionCooldown && gameState.currentPop < gameState.maxPopSize)
            {
                // Determine alleles of the offspring based on Punnett square
                AlleleType offspringAllele = DetermineOffspringAllele(GetComponent<BugAlleleScript>().alleleType, otherBug.GetComponent<BugAlleleScript>().alleleType);

                gameState.currentPop++;
                switch (offspringAllele)
                {
                    case AlleleType.Dom:
                        gameState.currentDom++;
                        break;
                    case AlleleType.Mid:
                        gameState.currentMid++;
                        break;
                    case AlleleType.Rec:
                        gameState.currentRec++;
                        break;
                }
                // Spawn a new bug with the determined alleles near the collision point
                SpawnOffspringBug(offspringAllele, collision.contacts[0].point);


                // Reset reproduction cooldown timer for this bug
                reproductionTimer = 0f;
            }
        }
    }

    AlleleType DetermineOffspringAllele(AlleleType allele1, AlleleType allele2)
    {

        // Dom allele
        if (allele1 == AlleleType.Dom)
        {
            if (allele2 == AlleleType.Dom)
            {
                // Dom x Dom -> Dom
                return AlleleType.Dom;
            }
            else if (allele2 == AlleleType.Mid)
            {
                // Dom x Mid -> 50% Dom, 50% Mid
                return Random.Range(0, 2) == 0 ? AlleleType.Dom : AlleleType.Mid;
            }
            else
            {
                // Dom x Rec -> Mid
                return AlleleType.Mid;
            }
        }
        // Mid allele
        else if (allele1 == AlleleType.Mid)
        {
            if (allele2 == AlleleType.Dom)
            {
                // Mid x Dom -> 50% Dom, 50% Mid
                return Random.Range(0, 2) == 0 ? AlleleType.Dom : AlleleType.Mid;
            }
            else if (allele2 == AlleleType.Mid)
            {
                // Mid x Mid -> 25% Dom, 50% Mid, 25% Rec
                int rand = Random.Range(0, 4);
                if (rand == 0)
                    return AlleleType.Dom;
                else if (rand == 1 || rand == 2)
                    return AlleleType.Mid;
                else
                    return AlleleType.Rec;
            }
            else
            {
                // Mid x Rec -> 50% Mid, 50% Rec
                return Random.Range(0, 2) == 0 ? AlleleType.Mid : AlleleType.Rec;
            }
        }
        // Rec allele
        else
        {
            if (allele2 == AlleleType.Dom)
            {
                // Rec x Dom -> Mid
                return AlleleType.Mid;
            }
            else if (allele2 == AlleleType.Mid)
            {
                // Rec x Mid -> 50% Mid, 50% Rec
                return Random.Range(0, 2) == 0 ? AlleleType.Mid : AlleleType.Rec;
            }
            else
            {
                // Rec x Rec -> Rec
                return AlleleType.Rec;
            }
        }
    }

    void SpawnOffspringBug(AlleleType allele, Vector2 position)
    {
        GameObject offspringBug;
        // Spawn a new bug GameObject with the determined allele at the specified position
        if(gameState.isGreenSelected)
        {
            if (allele == AlleleType.Dom || allele == AlleleType.Mid)
            {
                offspringBug = Instantiate(bugPrefabGreen, position, Quaternion.identity);
            }
            else
            {
                offspringBug = Instantiate(bugPrefabPurple, position, Quaternion.identity);
            }
        }
        else
        {
            if (allele == AlleleType.Dom || allele == AlleleType.Mid)
            {
                offspringBug = Instantiate(bugPrefabPurple, position, Quaternion.identity);
            }
            else
            {
                offspringBug = Instantiate(bugPrefabGreen, position, Quaternion.identity);
            }
        }
        

        
        offspringBug.GetComponent<BugAlleleScript>().alleleType = allele;

        
        

        
    }
}
