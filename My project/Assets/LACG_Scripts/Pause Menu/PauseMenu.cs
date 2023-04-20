using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;   
    public bool IsPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

  
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            if(IsPaused) 
            {
                
                ResumeGame();                
            }
            else
            {
                PauseGame();
            }
        
        }
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void GotToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
    }  
    
    public void QuitGame()
    {
        Application.Quit();
    }


}
