using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{/*
    public float damageTaken; // Se puede ajustar

    private void OnTriggerEnter(Collider other) //verificar este collider
    {
        if(other.CompareTag("Player") && other.GetComponent<HealthBar>()) // verifica si esta colisionando con jugador 
        {
            other.GetComponent<HealthBar>().TakeDamage(damageTaken); // Envia la cantidad de daño a HealthBar.cs
            Debug.Log("Moriste"); //Sale mensaje en caso de recibir daño y colisionar XD
        }
    }
    */
}

/* Ok detalles importantes primero, si se cambia el OnTriggerEnter no funciona, debe ser a causa de que quizas no estoy programando el collider correctamente, verificar eso. 
Siguiente, desde aqui se envia cuanto daño se le causa al jugador, no está "Hard coded" porque no se ha discutido cuanto daño deben hacer, pero se puede modificar desde Unity. Está programado para que si la 
bala toca al jugador salga el mensaje "Moriste" en el console, ya eso está probado, estar pendiente al hacer algun ajuste*/