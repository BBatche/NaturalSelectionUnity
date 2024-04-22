using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTransparencyScript : MonoBehaviour
{
    public GameObject Purplecontainer;
    public GameObject Greencontainer;
    public GameState gameState;
    private void Start()
    {
        if (gameState.isGreenSelected)
        {
            ChangeChildrenTransparency(Greencontainer, .5f);
            ChangeChildrenTransparency(Purplecontainer, 1f);
        }
        else
        {
            ChangeChildrenTransparency(Purplecontainer, .5f);
            ChangeChildrenTransparency(Greencontainer, 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameState.isGreenSelected)
        {
            ChangeChildrenTransparency(Greencontainer, .5f);
            ChangeChildrenTransparency(Purplecontainer, 1f);
        }
        else
        {
            ChangeChildrenTransparency(Purplecontainer , .5f);
            ChangeChildrenTransparency(Greencontainer, 1f);
        }
    }
    

    // Function to change transparency of children
    public void ChangeChildrenTransparency(GameObject container, float transparency)
    {
        // Ensure container is not null
        if (container != null)
        {
            // Iterate through each child of the container
            foreach (Transform child in container.transform)
            {
                // Check if the child has a Renderer component
                SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    // Get the current color
                    Color color = renderer.color;
                    // Update the alpha value to change transparency
                    color.a = transparency;
                    // Apply the new color to the material
                    renderer.color = color;
                }
            }
        }
        else
        {
            Debug.LogWarning("Container reference is not set.");
        }
    }
}
