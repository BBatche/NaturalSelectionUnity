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
        if(gameState.isGreenSelected)
        {
            Color fu = new Color(0f, 1f, 0f, 1f);
            background.GetComponent<SpriteRenderer>().color = fu;
        }
        else
        {
            Color fu2 = new Color(0.7024794f, 0f, 1f, 1f);
            background.GetComponent<SpriteRenderer>().color = fu2;
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
