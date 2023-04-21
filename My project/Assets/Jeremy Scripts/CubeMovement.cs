using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5.0f; // velocidad de movimiento del cubo

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // obtenemos el input horizontal (eje X)
        float vertical = Input.GetAxis("Vertical"); // obtenemos el input vertical (eje Z)

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical); // creamos un vector de movimiento con los inputs obtenidos
        transform.position += movement * speed * Time.deltaTime; // movemos el cubo en la dirección del vector de movimiento
    }
}