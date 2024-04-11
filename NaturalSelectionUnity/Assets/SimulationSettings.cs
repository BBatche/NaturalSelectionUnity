using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SimulationSettings : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    [SerializeField]
    GameObject background;
    [SerializeField]
    GameObject[] killZone1;
    [SerializeField]
    GameObject[] killZone2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameState.isWhiteSelected)
        {
            Color fuckyou = new Color(.1f, .1f, .1f, 1f);
            background.GetComponent<SpriteRenderer>().color = fuckyou;
        }
        else
        {
            Color fuckyou2 = new Color(.9f, .9f, .9f, 1f);
            background.GetComponent<SpriteRenderer>().color = fuckyou2;
        }

        if(!gameState.isManySelected)
        {
            foreach(GameObject kz in killZone2)
            {
                kz.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject kz in killZone2)
            {
                kz.SetActive(true);
            }
        }
    }
}
