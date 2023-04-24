using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    Transform Enemy;
    float distance;
    public float MaxDistance;
    public Transform head, barrel;
    public GameObject Proyectile,Turret_Legs;
    public float fireRate, nextFire;
    private float RotateAmount = 2;
    public int CurrentAmmoCount;
    private GameObject Turret_Support;
    public int BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
            return;
        distance = Vector3.Distance(Enemy.position, transform.position);
        //Vector3 targetPostition = new Vector3(agent.position.x, this.transform.position.y, agent.position.z);
        
        distance = Vector3.Distance(Enemy.position, transform.position);
        if (distance <= MaxDistance)
        {
            //transform.Rotate(Vector3.right * RotateAmount);
            //this.transform.LookAt(agent);
            head.LookAt(Enemy);
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 2f / fireRate;
                Shoot();
                //Invoke("Shoot", 5);
            }
        }
    }
    void updateTarget() 
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
            }
        }
        if(nearestEnemy !=null && shortestDistance <= MaxDistance) 
        {
            Enemy = nearestEnemy.transform;
        }
        else 
        {
            Enemy = null;
        }
    }

    void Shoot() 
    {
        if (CurrentAmmoCount > 0)
        {
            GameObject clone = Instantiate(Proyectile, barrel.position, head.rotation);
            clone.GetComponent<Rigidbody>().AddForce(head.forward * BulletSpeed);
            Destroy(clone, 10);
            CurrentAmmoCount--;
            if (CurrentAmmoCount <= 0) 
            {
                //Finds the object
                Turret_Support = GameObject.Find("Turret_Support");
                //destroys the object so thath the object is gone
                Destroy(Turret_Support);
                Destroy(Turret_Legs);
            }



        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject clone = Instantiate(Proyectile, barrel.position, head.rotation);
            clone.GetComponent<Rigidbody>().AddForce(head.forward * BulletSpeed);
            Destroy(clone);


        }
    }


}
