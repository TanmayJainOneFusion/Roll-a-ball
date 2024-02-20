using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
       
        myRenderer = GetComponent<Renderer>();

        
      
    }

    public void ChangeObjectColor(Color newColor)
    {
        myRenderer.material.color = newColor;
    }
}
