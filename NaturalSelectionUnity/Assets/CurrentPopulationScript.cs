using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentPopulationScript : MonoBehaviour
{

    [SerializeField]
    GameState gameState;
    [SerializeField]
    TMP_Text currBB;
    [SerializeField]
    TMP_Text currBb;
    [SerializeField]
    TMP_Text currbb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currBB.text = "Current Dom: " + gameState.currentDom;
        currBb.text = "Current Mid: " + gameState.currentMid;
        currbb.text = "Current Rec: " + gameState.currentRec;
    }
}
