using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "State/NaturalSelection")]
public class GameState : ScriptableObject
{
    public bool isWhiteSelected = false;
    public bool isFastSelected = false;
    public bool isRandomSelected = false;
    public bool isManySelected = false;
    public int initalPopSize = 0;
    public int initialBB = 0;
    public int initialBb = 0;
    public int initialbb = 0;
    public int maxPopSize = 200;
    public bool simStarted = false;
    public float speed = 1.5f;
    public string userEmail = "";
    public string simulationID = "";
    public enum AlleleType
    {
        BB,
        Bb,
        bb
    }

    public int currentPop = 0;
    public int currentDom = 0;
    public int currentMid = 0;
    public int currentRec = 0;
    public int killedByKillZone = 0;
    public int killedByPlayer = 0;
    public int currentGen = 0;
    public Color domColor = Color.white;
    public Color recColor = Color.white;
}
