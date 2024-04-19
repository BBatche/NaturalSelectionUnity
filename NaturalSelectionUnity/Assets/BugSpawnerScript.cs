using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugMovementScript;

public class BugSpawnerScript : MonoBehaviour
{
    public GameObject bugPrefabPurple; // Prefab of the bug to spawn
    public GameObject bugPrefabGreen;
    public GameState gameState; // Reference to the GameState script
    public Rect spawnArea; // Rectangle defining the spawn area

    public Color BBColor = Color.red; 
    public Color BbColor = Color.green; 
    public Color bbColor = Color.blue;
    void Start()
    {
        gameState.currentMid = 0;
        gameState.currentDom = 0;
        gameState.currentPop = 0;
        gameState.currentRec = 0;
        gameState.killedByKillZone = 0;
        gameState.killedByPlayer = 0;
        SpawnBugs();
    }

    private void SpawnBugs()
    {
        SpawnBugsOfType(gameState.initialBB, BugAlleleScript.AlleleType.Dom);
        SpawnBugsOfType(gameState.initialBb, BugAlleleScript.AlleleType.Mid);
        SpawnBugsOfType(gameState.initialbb, BugAlleleScript.AlleleType.Rec);
    }

    private void SpawnBugsOfType(int count, BugAlleleScript.AlleleType alleleType)
    {
        for (int i = 0; i < count; i++)
        {   

            gameState.currentPop++;
            switch (alleleType)
            {
                case BugAlleleScript.AlleleType.Dom: gameState.currentDom++; break;
                case BugAlleleScript.AlleleType.Mid: gameState.currentMid++; break;
                case BugAlleleScript.AlleleType.Rec: gameState.currentRec++; break;
            }
            // Generate random position within the spawn area
            Vector2 spawnPosition = new Vector2(Random.Range(spawnArea.xMin, spawnArea.xMax), Random.Range(spawnArea.yMin, spawnArea.yMax));

            GameObject newBug;
            if (gameState.isGreenSelected)
            {
                if (alleleType == BugAlleleScript.AlleleType.Dom || alleleType == BugAlleleScript.AlleleType.Mid)
                {
                    newBug = Instantiate(bugPrefabGreen, spawnPosition, Quaternion.identity);
                }
                else
                {
                    newBug = Instantiate(bugPrefabPurple, spawnPosition, Quaternion.identity);
                }
            }
            else
            {
                if (alleleType == BugAlleleScript.AlleleType.Dom || alleleType == BugAlleleScript.AlleleType.Mid)
                {
                    newBug = Instantiate(bugPrefabPurple, spawnPosition, Quaternion.identity);
                }
                else
                {
                    newBug = Instantiate(bugPrefabGreen, spawnPosition, Quaternion.identity);
                }
            }
            
            // Set allele type of the bug using BugAlleleScript
            newBug.GetComponent<BugAlleleScript>().SetAlleleType(alleleType);
            
        }
    }
}
