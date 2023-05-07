using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceHealth : MonoBehaviour
{
    public float Health;

    //Vida del enemigo
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            DestroyEnemy();
        }


    }

    void DestroyEnemy()
    {
        //Debug.Log("Enemy died!!!");
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }


}
