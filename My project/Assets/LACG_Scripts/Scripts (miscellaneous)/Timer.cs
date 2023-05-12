using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemainig = 1;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
  

    private void Start()
    {
        timeIsRunning = true;
    }
    private void Update()
    {
        if(timeIsRunning)
        {
            if (timeRemainig >= 0) 
            {
                timeRemainig -= Time.deltaTime;
                DisplayTime(timeRemainig);
            }
            
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay > 1)
        {
            timeToDisplay -= 1;
        }
        else if (timeToDisplay <= 1)
        {

            SceneManager.LoadScene("Winner");
        }
        // timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float Seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, Seconds);
    }


}
