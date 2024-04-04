using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NaturalSelectionUnity.Models.Simulation;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine.Networking;
using TMPro;
public class APIService : MonoBehaviour
{
    private readonly HttpClient _httpClient;

    private static readonly string baseURL = "http://localhost:5073/api/";

    public static readonly string simApiUrl = "http://localhost:5073/api/Simulations";

    public TextMeshProUGUI text;

    private void Start()
    {
        
    }

    public IEnumerator GetSimulationRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    List<Simulation> simData = JsonConvert.DeserializeObject<List<Simulation>>(webRequest.downloadHandler.text);
                    foreach (Simulation sim in simData)
                    {
                        text.text = sim.SimulationId.ToString() + " " +  sim.UserEmail;
                    }
                    break;
            }
        }


    }
    /*
    public APIService() { 
        
        _httpClient = new HttpClient();

    }
    
    async public Task<List<Simulation>> GetSimulationsAsync()
    {
        Debug.Log("In method");
        string apiUrl = simApiUrl;
        

        List<Simulation> sim = null; 
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                Debug.Log(response.IsSuccessStatusCode);
                if(response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    sim = JsonConvert.DeserializeObject<List<Simulation>>(jsonString);

                }
                else
                {
                    Debug.Log("API request failed with status code: "  + response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Error: " + ex.StackTrace);
                return null;
            }
            Debug.Log("return sim");
            return sim;
        }
    }

    public void SayHi()
    {
        Debug.Log("Hi");
    }
    */
}
