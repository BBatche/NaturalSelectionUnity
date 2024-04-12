using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugAlleleScript;
public class BugReproductionScript : MonoBehaviour
{
    public GameObject bugPrefab;
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
            if (reproductionTimer >= reproductionCooldown && otherBug.reproductionTimer >= otherBug.reproductionCooldown)
            {
                // Determine alleles of the offspring based on Punnett square
                AlleleType offspringAllele = DetermineOffspringAllele(GetComponent<BugAlleleScript>().alleleType, otherBug.GetComponent<BugAlleleScript>().alleleType);

                // Spawn a new bug with the determined alleles near the collision point
                SpawnOffspringBug(offspringAllele, collision.contacts[0].point);

                // Reset reproduction cooldown timer for this bug
                reproductionTimer = 0f;
            }
        }
    }

    AlleleType DetermineOffspringAllele(AlleleType allele1, AlleleType allele2)
    {
        // Implement Punnett square logic to determine offspring alleles based on parent alleles
        // This logic will depend on the specific genetics of your bugs

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
        // Spawn a new bug GameObject with the determined allele at the specified position
        GameObject offspringBug = Instantiate(bugPrefab, position, Quaternion.identity);
        offspringBug.GetComponent<BugAlleleScript>().alleleType = allele;

        
        

        // Assign the appropriate color based on allele type
        switch (allele)
        {
            case AlleleType.Dom:
                offspringBug.GetComponent<Renderer>().material.color = Color.red;
                break;
            case AlleleType.Mid:
                offspringBug.GetComponent<Renderer>().material.color = Color.green;
                break;
            case AlleleType.Rec:
                offspringBug.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
}
