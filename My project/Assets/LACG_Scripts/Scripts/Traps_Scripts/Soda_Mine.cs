using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Soda_Mine : MonoBehaviour
{
    //[SerializeField] int maxDamage = 100;
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    float countdown;

    private GameObject Soda_mine;

    //Has to happen when it colifdes with enemy
    void Start()
    {
     countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Explode();
        }
    }

    public void Explode()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObjects in colliders) 
        {
           Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if (rb != null) 
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Verifies if the object has the game component if it has it it will activate
    //    //if (collision.gameObject.TryGetComponent<Enemy_States>(out Enemy_States enemyComponent))
    //    //{
    //    //    enemyComponent.TakeDamage(50);
    //    //}
    //}


    //void OnTriggerEnter(Collider other)
    //{
    //    //anything with the enemy tag the mine will activate
    //    if (other.tag == "Agent")
    //    {
    //        //Finds the object
    //        //Soda_mine = GameObject.Find("Soda_Mine");

    //        Destroy(other.gameObject);
    //        //destroys the object so thath the object is gone
    //        Destroy(Soda_mine);
    //    }
    //}
}
