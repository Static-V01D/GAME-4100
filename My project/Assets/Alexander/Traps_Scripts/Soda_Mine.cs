using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Mine : MonoBehaviour
{
    //[SerializeField] int maxDamage = 100;

    private GameObject Soda_mine;
    private float radius = 5f;
    public float force = 700f;
    float countdown;
    public float delay = 2.5f;
    bool hasExploded = false;
    

    void Start()
    {
        countdown = delay;

    }
    void LateUpdate()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

    }
    
   

    private void OnCollisionEnter(Collision collision)
    {
       
        //Verifies if the object has the game component if it hasit it will activate
        if (collision.gameObject.TryGetComponent<Enemy_States>(out Enemy_States enemyComponent))
        {
            //enemyComponent.TakeDamage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
       

        if (other.tag == "Agent")
        {
            //Finds the object
            Soda_mine = GameObject.Find("Soda_Mine");
            transform.localEulerAngles = new Vector3(90f, 0f, 0f);

        }

    }

    void Explode() 
    {
       Collider[] coliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in coliders) 
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null) 
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        //destroys the object so thath the object is gone
        Destroy(Soda_mine,1);
    }
}
