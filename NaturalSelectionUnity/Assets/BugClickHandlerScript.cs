using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugClickHandlerScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
