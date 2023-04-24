using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxhealth;
    [SerializeField] private HealthBar healthBar;


    private void Start()
    {
        health = maxhealth;
        healthBar.InitializeHealthBar(health);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.ChangeCurrentHealth(health);
        if (health < 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }
    public void healing(float Heal)
    {    
        if ((health> maxhealth))
        {
            health = maxhealth;
            healthBar.ChangeCurrentHealth(health);
        }
        else
        {
            health += Heal;
            healthBar.ChangeCurrentHealth(health);
        }
    }
    private void Update()
    {
        Death();
    }
    public void Death() 
    {
        if(health <= 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("DeathMenu");

        }
    
    
    
    }
}
