using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
   

    public float radius = 10f;
    public float explosionForce = 10f;
    public LayerMask enemyLayers;

    public GameObject Explosion;
     public int attackDamage = 50;

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    
    }
    private void Explode()
    {
        Collider[] colldier = Physics.OverlapSphere(transform.position, radius, enemyLayers);

        foreach (Collider col in colldier)
        {

            Rigidbody rig = col.GetComponent<Rigidbody>();

            if (rig != null)
            {             

               rig.AddExplosionForce(explosionForce, transform.position, radius, 2F, ForceMode.Impulse);

               col.GetComponent<Enemy_States>().TakeDamage(attackDamage);
               col.GetComponent<Culson_States>().CulsonTakeDamage(attackDamage);

                Explosion.SetActive(true);               
            }
            

        }

        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
      
    }
}


