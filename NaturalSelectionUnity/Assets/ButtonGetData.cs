using NaturalSelectionUnity.Models.Simulation;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonGetData : MonoBehaviour
{

    public APIService apiService; // Reference to your APIService script

    private void Start()
    {
        // Find and assign the APIService component
        apiService = FindObjectOfType<APIService>();
    }

    public void OnButtonClick()
    {
        Debug.Log("Button click");
        StartCoroutine(HandleButtonClick());
    }

    private IEnumerator HandleButtonClick()
    {
        // Call the async method and wait for it to complete
        Task<List<Simulation>> task = apiService.GetSimulationsAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        // Now you can process the result or handle any errors
        if (task.Exception != null)
        {
            Debug.LogError("Error: " + task.Exception);
        }
        else
        {
            List<Simulation> simulations = task.Result;
            Debug.Log(simulations + " 0i0549320592");
        }
    }
}


