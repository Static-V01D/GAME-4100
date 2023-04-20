using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject Death_Menu;
    public void GotToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
    }
    public void Level_Select()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }    
    public void QuitGame()
    {
        Application.Quit();
    }

}
