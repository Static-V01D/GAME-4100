using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Mine : MonoBehaviour
{
    //[SerializeField] int maxDamage = 100;

    private GameObject Soda_mine;
    public bool MineRotate = false;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        //Verifies if the object has the game component if it hasit it will activate
        if (collision.gameObject.TryGetComponent<Enemy_States>(out Enemy_States enemyComponent))
        {
            //enemyComponent.TakeDamage(50);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        
        //anything with the enemy tag the mine will activate
        if (other.tag == "Agent")
        {
            //transform.Rotate(-90f, 0f, 0f, Space.Self);
            transform.localEulerAngles = new Vector3(90f, 0f, 0f);

            //Finds the object
            Soda_mine = GameObject.Find("Soda_Mine");
            //destroys the object so thath the object is gone
            Destroy(Soda_mine,3);
           
        }
    }
}
