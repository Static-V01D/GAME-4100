using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxhealth;
    [SerializeField] private HealthBar healthBar;


    private void Start()
    {
        health = maxhealth;
        healthBar.InitializeHealthBar(health);
    }

    public void CoreTakeDamage(float damage)
    {
        health -= damage;
        healthBar.ChangeCurrentHealth(health);
        if (health < 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }
    
    private void Update()
    {
        Death();
    }
    public void Death()
    {
        if (health <= 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("DeathMenu");

        }



    }
}
