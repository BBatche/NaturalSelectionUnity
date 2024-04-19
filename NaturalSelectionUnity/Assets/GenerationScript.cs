using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using NaturalSelectionUnity.Models.Simulation;
using NaturalSelectionUnity.Models.Generation;
using Newtonsoft.Json;
using System.Linq;
using System;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;
public class GenerationScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text genText;
    [SerializeField]
    GameState gameState;
    private int value = 0;
    private WaitForSeconds waitTime = new WaitForSeconds(10f);
    string genUrl = "http://localhost:5073/api/Generations";
    string simUrl = "http://localhost:5073/api/Simulations";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncrementTextValue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncrementTextValue()
    {
        
        while (true)
        {
            // Increment the value
            value++;

            // Update the text component with the new value
            
            gameState.currentGen = value;
            genText.text = "Generation: " + value.ToString();
            

            // Wait for 10 seconds
            yield return waitTime;
            

            
            
            Generation genPost = CreateGeneration();
            StartCoroutine(PostGeneration(genPost));

            if(gameState.currentGen > 6)
            {
                SceneManager.LoadScene("ExportPage");
            }
        }
    }
    public Generation CreateGeneration()
    {
        Generation gen = new Generation();
        gen.PopulationRecessive = gameState.currentRec;
        gen.PopulationMiddle = gameState.currentMid;
        gen.PopulationDominant = gameState.currentDom;
        gen.PopulationCount = gameState.currentPop;
        gen.GenerationNum = gameState.currentGen;
        gen.KilledByKillzone = gameState.killedByKillZone;
        gen.KilledByPlayer = gameState.killedByPlayer;
        gen.SimulationId = gameState.simulationID;
        return gen;
    }
    IEnumerator PostGeneration(Generation gen)
    {
        string jsonData = JsonConvert.SerializeObject(gen);

        
        using (UnityWebRequest request = new UnityWebRequest(genUrl, "POST"))
        {
            
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Content-Type", "application/json");

            
            yield return request.SendWebRequest();

            
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error posting generation: " + request.error);
            }
            else
            {
                Debug.Log("generation posted successfully!");
            }
        }
    }
}
