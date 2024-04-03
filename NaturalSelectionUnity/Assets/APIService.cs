using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NaturalSelectionUnity.Models.Simulation;
using System;
using System.Threading.Tasks;
using System.Net.Http;
public class APIService : MonoBehaviour
{
    private readonly HttpClient _httpClient;

    private static readonly string baseURL = "https://localhost:7075/api/";

    private static readonly string simApiUrl = "https://localhost:7075/api/Simulations";
    private void Start()
    {
        
    }
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
                Debug.Log("Error: " + ex.Message);
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
}
