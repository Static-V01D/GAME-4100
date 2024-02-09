using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Mine : MonoBehaviour
{
    //[SerializeField] int maxDamage = 100;

    private GameObject Soda_mine;
    private float radius = 20f;
    public float force = 700f;
    float countdown;
    public float delay = 2.5f;
    bool hasExploded = false;
    public GameObject Explosion;

    void Start()
    {
        countdown = delay;

    }
    void Update()
    {
        


    }


    //void Explode()
    //{
    //    Collider[] coliders = Physics.OverlapSphere(transform.position, radius);
    //    foreach (Collider nearbyObject in coliders)
    //    {
    //        Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            rb.AddExplosionForce(force, transform.position, radius);
    //        }
    //    }
    //    //destroys the object so thath the object is gone
    //    Destroy(Soda_mine, 1);

    //
    //}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            countdown -= Time.deltaTime;
           // if (countdown == 0f)     
           // {
                Collider[] coliders = Physics.OverlapSphere(transform.position, radius);
                foreach (Collider nearbyObject in coliders)
                {
                    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

                    rb.AddExplosionForce(force, transform.position, radius);
                    Soda_mine = GameObject.Find("Soda_Mine");
                    Destroy(Soda_mine, 1);
                 Explosion.SetActive(true);
                }
            //}
            
            //destroys the object so thath the object is gone

            //Finds the object
           


        }

    }

   
}
