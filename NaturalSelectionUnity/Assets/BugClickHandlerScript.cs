using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BugAlleleScript;

public class BugClickHandlerScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    private void OnMouseDown()
    {
        gameState.killedByPlayer++;
        gameState.currentPop--;
        BugAlleleScript bugAlleleScript = GetComponent<BugAlleleScript>();
        if (bugAlleleScript != null)
        {
           AlleleType bugType =  bugAlleleScript.getAlleleType();

            switch(bugType)
            {
                case AlleleType.Dom:
                    gameState.currentDom--;
                    break;
                case AlleleType.Mid:
                    gameState.currentMid--;
                    break;
                case AlleleType.Rec:
                    gameState.currentRec--;
                    break;
            }
        }
        Destroy(gameObject);
    }
}
