using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePass : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GAMEMENU");
    }
}
