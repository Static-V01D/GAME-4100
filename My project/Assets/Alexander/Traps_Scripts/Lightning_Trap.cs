
using UnityEngine;
using UnityEngine.AI;



public class Lightning_Trap : MonoBehaviour
{
    public float slowdownFactor = 0.5f; // Adjust this value to control the slowdown factor
    
    public int attackDamage = 100;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a NavMeshAgent component
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            // Reduce the agent's speed by the slowdown factor
            agent.speed *= slowdownFactor;

            // Start damaging the object over time
            StartDamagingObject(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has a NavMeshAgent component
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            // Reset the agent's speed to its original value
            agent.speed /= slowdownFactor;

            // Stop damaging the object
            StopDamagingObject(other.gameObject);
        }
    }

    private void StartDamagingObject(GameObject target)
    {
        // Start invoking the DamageObject function every second
        InvokeRepeating("DamageObject", 50f, 1f);
        target.GetComponent<Enemy_States>().TakeDamage(attackDamage);
        target.GetComponent<Culson_States>().CulsonTakeDamage(20);
       
    }

    private void StopDamagingObject(GameObject target)
    {
        // Stop invoking the DamageObject function
        CancelInvoke("DamageObject");
    }
    private void DamageObject()
    {
        // Apply damage to the object by seconds
        // You can modify this function to fit your specific damage logic
        // For example, you can reduce the object's health or trigger an event

        // For demonstration purposes, let's just log the damage
        Debug.Log("Object damaged by " + attackDamage + " per second.");
        
    }

}
