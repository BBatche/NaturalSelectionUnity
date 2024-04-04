using NaturalSelectionUnity.Models.Simulation;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonGetData : MonoBehaviour
{
    public static readonly string simApiUrl = "http://localhost:5073/api/Simulations";
    public APIService apiService; // Reference to your APIService script

    private void Start()
    {
        // Find and assign the APIService component
       apiService = FindObjectOfType<APIService>();
    }

    public void OnButtonClick()
    {
        Debug.Log("Button click");
        StartCoroutine(apiService.GetSimulationRequest(simApiUrl));
    }

   
}


