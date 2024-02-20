using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoundingBox : MonoBehaviour
{
    // Reference to the Renderer component
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the GameObject
        myRenderer = GetComponent<Renderer>();

        // Check if the Renderer component exists
        if (myRenderer == null)
        {
            Debug.LogError("Renderer component not found!");
        }
    }

    // Function to change the color of the object
    public void ChangeObjectColor(Color newColor)
    {
        // Change the material color to the newColor
        myRenderer.material.color = newColor;
    }
}

