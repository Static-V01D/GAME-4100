using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   // public float health = 50;  // La cantidad actual de salud del personaje
   // public float maxHealth = 100;   // La cantidad máxima de salud del personaje

  //  [Header("Interface")]
  //  public Image HealthImg; //Aqui es para colocar el objeto HealthBar de Unity y que funcione como slider
   // public Text HealthText; //Texto que muestra el porcentaje de Salud

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(float Health)
    {
        slider.value = Health;
    }

    public void InitializeHealthBar(float Health)
    {
        ChangeMaxHealth(Health);
        ChangeCurrentHealth(Health);
    }
















    /*

    void Update()
    {
        UpdateInterface();
       
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void UpdateInterface()
    {
        HealthImg.fillAmount = health / maxHealth;
        HealthText.text = health.ToString("f0");
    }

  */

}


/*Este script contiene algunos elementos que mostrará al jugador, lo demás es la funcion tomar daño la cual recibe la info de cuanto daño debe recibir desde el script de bullet.cs, más detalles allá...*/