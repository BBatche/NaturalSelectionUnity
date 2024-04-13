using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GenerationScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text genText;
    [SerializeField]
    GameState gameState;
    private int value = 0;
    private WaitForSeconds waitTime = new WaitForSeconds(10f);
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
        }
    }
}
