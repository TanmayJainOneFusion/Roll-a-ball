using UnityEngine;
using TMPro;
 
public class PauseEscape : MonoBehaviour
{
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public TMP_Dropdown dropdown3;
    
    
 
    private bool isPaused = false;
    private float originalTimeScale;
 
    void Start()
    {
        
       DropdownDeactivate(); 
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
 
    public void TogglePause()
    {
        isPaused = !isPaused;
 
        if (isPaused)
        {
            PauseGame();
            DropdownActivate();
            
        }
        else
        {
            
            ResumeGame();
        }
        
    }
 
 
    
 
    
 
    public void DropdownActivate()
    {
        
        dropdown1.gameObject.SetActive(true);
        dropdown2.gameObject.SetActive(true);
        dropdown3.gameObject.SetActive(true);
    }
 
    public void DropdownDeactivate()
    {
        
        dropdown1.gameObject.SetActive(false);
        dropdown2.gameObject.SetActive(false);
        dropdown3.gameObject.SetActive(false);
        
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        
        isPaused = false;
        DropdownDeactivate();
        Time.timeScale = 1f;
    }

}