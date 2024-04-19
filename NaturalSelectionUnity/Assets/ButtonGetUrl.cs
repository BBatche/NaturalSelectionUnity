using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGetUrl : MonoBehaviour
{
    public GameState gameState; 

    public void ExportToExcel()
    {
        string baseURL = "http://localhost:5073/api/SettingsGenerations/ExportSettingsAndGenerationsToExcel?userEmail=";
        string userEmail = gameState.userEmail; 

        
        string fullURL = baseURL + userEmail;

        Application.OpenURL(fullURL);
    }
}
