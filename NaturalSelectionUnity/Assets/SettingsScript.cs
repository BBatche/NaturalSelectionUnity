using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NaturalSelectionUnity.Models.Settings;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Text;

public class SettingsScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    [SerializeField]
    Button fastButton;
    [SerializeField]
    Button slowButton;

    [SerializeField]
    Button manyButton;
    [SerializeField]
    Button fewButton;
    [SerializeField]
    Button randomButton;
    [SerializeField]
    Button linearButton;
    [SerializeField]
    Button blackButton;
    [SerializeField]
    Button whiteButton;
    [SerializeField]
    Button startButton;
    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    TMP_InputField emailField;
    [SerializeField]
    TMP_InputField initialBB;
    [SerializeField]
    TMP_InputField initialBb;
    [SerializeField]
    TMP_InputField initialbb;

    string apiUrl = "http://localhost:5073/api/Settings";
    // Start is called before the first frame update
    void Start()
    {

        gameState.isWhiteSelected = false;
        gameState.isFastSelected = false;
        gameState.isRandomSelected = false;
        gameState.isManySelected = false;
        gameState.initalPopSize = 0;
        gameState.maxPopSize = 200;
        gameState.simStarted = false;
        gameState.speed = 1.5f;
        gameState.userEmail = string.Empty;

        gameState.currentPop = 0;
        gameState.currentDom = 0;
        gameState.currentMid = 0;
        gameState.currentRec = 0;
        gameState.killedByKillZone = 0;
        gameState.killedByPlayer = 0;
        gameState.currentGen = 0;
        gameState.initialBB = 0;
        gameState.initialBb = 0;
        gameState.initialbb = 0;




        ColorBlock cb = slowButton.colors;
        cb.selectedColor = Color.gray;
        fastButton.colors = cb;
        slowButton.colors = cb;
        manyButton.colors = cb;
        fewButton.colors = cb;
        randomButton.colors = cb;
        linearButton.colors = cb;
        blackButton.colors = cb;
        whiteButton.colors = cb;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlowSpeed()
    {
        if (!gameState.simStarted)
        {
            gameState.speed = 1.5f;
            gameState.isFastSelected = false;

            ColorBlock cb = slowButton.colors;
            cb.normalColor = Color.gray;
            slowButton.colors = cb;

            ColorBlock cbb = fastButton.colors;
            cbb.normalColor = Color.white;
            fastButton.colors = cbb;
        }

    }

    public void FastSpeed()
    {
        if (!gameState.simStarted)
        {
            gameState.speed = 3f;
            gameState.isFastSelected = true;
            ColorBlock cb = fastButton.colors;
            cb.normalColor = Color.gray;
            fastButton.colors = cb;

            ColorBlock cbb = slowButton.colors;
            cbb.normalColor = Color.white;
            slowButton.colors = cbb;
        }
    }
    public void RandomMovement()
    {
        if (!gameState.simStarted)
        {
            gameState.isRandomSelected = true;
            ColorBlock cb = randomButton.colors;
            cb.normalColor = Color.gray;
            randomButton.colors = cb;

            ColorBlock cbb = linearButton.colors;
            cbb.normalColor = Color.white;
            linearButton.colors = cbb;
        }
    }
    public void LinearMovement()
    {
        if (!gameState.simStarted)
        {
            gameState.isRandomSelected = false;

            ColorBlock cb = linearButton.colors;
            cb.normalColor = Color.gray;
            linearButton.colors = cb;

            ColorBlock cbb = randomButton.colors;
            cbb.normalColor = Color.white;
            randomButton.colors = cbb;
        }
    }

    public void ChangeColorBlack()
    {
        if (!gameState.simStarted)
        {
            gameState.isWhiteSelected = false;

            ColorBlock cbb = blackButton.colors;
            cbb.normalColor = Color.gray;
            blackButton.colors = cbb;

            ColorBlock cb = whiteButton.colors;
            cb.normalColor = Color.white;
            whiteButton.colors = cb;

            
        }
    }
    public void ChangeColorWhite()
    {
        if (!gameState.simStarted)
        {
            gameState.isWhiteSelected = true;

            ColorBlock cb = blackButton.colors;
            cb.normalColor = Color.white;
            blackButton.colors = cb;

            ColorBlock cbb = whiteButton.colors;
            cbb.normalColor = Color.gray;
            whiteButton.colors = cbb;
        }
    }

    public void StartSim()
    {
        gameState.simStarted = true;
        Guid guid = Guid.NewGuid();
        gameState.simulationID = guid.ToString();

        Setting setting = new Setting();
        CreateSetting(setting);
        StartCoroutine(PostSettings(setting));
        SceneManager.LoadScene("Simulation Screen");

    }

    private void CreateSetting(Setting setting)
    {
        if (gameState.isFastSelected)
        {
            setting.MovementSpeed = 3;
        }
        else
        {
            setting.MovementSpeed = 1;
        }
        if (gameState.isManySelected)
        {
            setting.KillZones = 6;
        }
        else
        {
            setting.KillZones = 4;
        }
        if (gameState.isRandomSelected)
        {
            setting.MovementType = "Random";
        }
        else
        {
            setting.MovementType = "Linear";
        }
        if (gameState.isWhiteSelected)
        {
            setting.BackgroundColor = "Light";
        }
        else
        {
            setting.BackgroundColor = "Dark";
        }
        setting.BeginningDominant = gameState.initialBB;
        setting.BeginningMiddle = gameState.initialBb;
        setting.BeginningRecessive = gameState.initialbb;
        setting.UserEmail = gameState.userEmail;
        setting.BeginningPopulation = (gameState.initialBb + gameState.initialBB + gameState.initialbb);
    }

    public void ReadInputField()
    {
        // Assuming this script is attached to the GameObject containing the InputField
        if (inputField != null)
        {
            string inputText = inputField.text;
            Debug.Log("Input Text: " + inputText);
        }
        else
        {
            Debug.LogError("InputField reference is not set!");
        }
    }

    public void ReadEmail()
    {
        if (emailField != null)
        {
            string emailText = emailField.text;
            Debug.Log("Email Text: " + emailText);
            gameState.userEmail = emailText;
        }
    }

    public void FewKillZones()
    {
        gameState.isManySelected = false;
        ColorBlock cb = fewButton.colors;
        cb.normalColor = Color.gray;
        fewButton.colors = cb;

        ColorBlock cbb = manyButton.colors;
        cbb.normalColor = Color.white;
        manyButton.colors = cbb;
    }

    public void ManyKillZones()
    {
        gameState.isManySelected = true;
        ColorBlock cb = manyButton.colors;
        cb.normalColor = Color.gray;
        manyButton.colors = cb;

        ColorBlock cbb = fewButton.colors;
        cbb.normalColor = Color.white;
        
        fewButton.colors = cbb;
    }

    public void ReadBB()
    {
        // Check if the input field is not null and not empty
        if (initialBB != null && !string.IsNullOrEmpty(initialBB.text))
        {
            // Parse the text to an integer and assign it to the gameState variable
            gameState.initialBB = int.Parse(initialBB.text);
        }
    }

    public void ReadBb()
    {
        // Check if the input field is not null and not empty
        if (initialBb != null && !string.IsNullOrEmpty(initialBb.text))
        {
            // Parse the text to an integer and assign it to the gameState variable
            gameState.initialBb = int.Parse(initialBb.text);
        }
    }

    public void Readbb()
    {
        // Check if the input field is not null and not empty
        if (initialbb != null && !string.IsNullOrEmpty(initialbb.text))
        {
            // Parse the text to an integer and assign it to the gameState variable
            gameState.initialbb = int.Parse(initialbb.text);
        }
    }

    IEnumerator PostSettings(Setting settings)
    {
        string jsonData = JsonConvert.SerializeObject(settings);

        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(apiUrl, "POST"))
        {
            // Set the request body
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error posting settings: " + request.error);
            }
            else
            {
                Debug.Log("Settings saved successfully!");
            }
        }
    }
}

