using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGetUrl : MonoBehaviour
{
    public void OnButtonClick()
    {
        Application.OpenURL("http://localhost:5073/api/Simulations/ExportSim");
    }
}
