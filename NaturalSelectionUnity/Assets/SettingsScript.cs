using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

            ColorBlock cb = whiteButton.colors;
            cb.normalColor = Color.gray;
            whiteButton.colors = cb;

            ColorBlock cbb = blackButton.colors;
            cbb.normalColor = Color.white;
            blackButton.colors = cbb;
        }
    }
    public void ChangeColorWhite()
    {
        if (!gameState.simStarted)
        {
            gameState.isWhiteSelected = true;

            ColorBlock cb = blackButton.colors;
            cb.normalColor = Color.gray;
            blackButton.colors = cb;

            ColorBlock cbb = whiteButton.colors;
            cbb.normalColor = Color.white;
            whiteButton.colors = cbb;
        }
    }

    public void StartSim()
    {
        gameState.simStarted = true;
        Guid guid = Guid.NewGuid();
        gameState.simulationID = guid.ToString();
        SceneManager.LoadScene("Simulation Screen");
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
    }

    public void ManyKillZones()
    {
        gameState.isManySelected = true;
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
}
