using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugColorScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    
    private void Start()
    {
        

        Debug.Log("domColor: " + gameState.domColor);
        Debug.Log("recColor: " + gameState.recColor);

    }

}
