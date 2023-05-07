using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Lightning_Trap : MonoBehaviour
{
    //Variables
    Transform Enemy;
    GameObject Water_puddle;
    public int slow = 5;
    public int Damage = 100;
    public int Trap_Health = 100;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void OnTriggerEnter(Collider other)
    {
        

    }
}
