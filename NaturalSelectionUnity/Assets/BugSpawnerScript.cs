using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugMovementScript;

public class BugSpawnerScript : MonoBehaviour
{
    public GameObject bugPrefab; // Prefab of the bug to spawn
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

            // Instantiate bug prefab at the random position
            GameObject newBug = Instantiate(bugPrefab, spawnPosition, Quaternion.identity);

            // Set allele type of the bug using BugAlleleScript
            newBug.GetComponent<BugAlleleScript>().SetAlleleType(alleleType);
            SetBugColor(newBug, alleleType);
        }
    }

    private void SetBugColor(GameObject bug, BugAlleleScript.AlleleType alleleType)
    {
        if (gameState.isWhiteSelected)
        {
            gameState.domColor = new Color(31 / 255f, 65 / 255f, 33 / 255f, 1f);
            gameState.recColor = new Color(99 / 255f, 99 / 255f, 99 / 255f, 1f);


        }
        else
        {
            gameState.domColor = Color.white;
            gameState.recColor = Color.black;
        }
        // Set color of the bug based on allele type
        switch (alleleType)
        {
            case BugAlleleScript.AlleleType.Dom:
                bug.GetComponent<Renderer>().material.color = gameState.domColor;
                Debug.Log("Bug with allele type BB: Color set to " + gameState.domColor);
                break;
            case BugAlleleScript.AlleleType.Mid:
                bug.GetComponent<Renderer>().material.color = gameState.domColor;
                Debug.Log("Bug with allele type Bb: Color set to " + BbColor);
                break;
            case BugAlleleScript.AlleleType.Rec:
                bug.GetComponent<Renderer>().material.color = gameState.recColor;
                Debug.Log("Bug with allele type bb: Color set to " + bbColor);
                break;
            default:
                break;
        }
    }

}
