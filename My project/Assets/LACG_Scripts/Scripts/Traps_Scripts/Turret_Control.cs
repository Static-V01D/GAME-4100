using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    Transform agent;
    float distance;
    public float MaxDistance;
    public Transform head, barrel;
    public GameObject Proyectile;
    public float fireRate, nextFire;
    private float RotateAmount = 2;

    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.FindGameObjectWithTag("Agent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.position, transform.position);
        Vector3 targetPostition = new Vector3(agent.position.x, this.transform.position.y, agent.position.z);
        if (distance <= MaxDistance) 
        {
            //transform.Rotate(Vector3.right * RotateAmount);
            this.transform.LookAt(agent);
            //head.LookAt(agent);
            if(Time.time >= nextFire) 
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();
            }
            
        }
    }

    void Shoot() 
    {
       GameObject clone = Instantiate(Proyectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * 20);
        Destroy(clone, 10);

    }
}
