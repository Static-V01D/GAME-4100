using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelSelectMenu;
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
    public void Stage1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Char_CONT");
    }
    public void Stage2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Char_CONT");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
