using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Char_CONT");
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }

}
