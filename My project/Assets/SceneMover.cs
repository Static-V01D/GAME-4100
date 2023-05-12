using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}
