//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices.WindowsRuntime;
//using UnityEngine;
//using UnityEngine.AI;
//using UnityEngine.UIElements;

//public class Shapnell_Turret : MonoBehaviour
//{
//    [SerializeField] private float attackCooldown;
//    //[SerializeField] private Transform firePoint;
//    [SerializeField] private GameObject Sharpnell;
//    public float timeBetweenAttacks;
//    bool alreadyAttacked;
//    public Transform player;
//    public NavMeshAgent agent;


//    private float cooldownTimer;
    
//    private void Attack() 
//    {
//        //cooldownTimer = 0;
//        //Sharpnell[FindSharpnell()].transform.position = firePoint.position;
//        //Sharpnell[FindSharpnell()].GetComponent<Advanced_Proyectile>().ActivateProyectile();
//    }

//    private void AttackPlayer()
//    {
//        //Make sure enemy doesn't move while attacking
//        agent.SetDestination(transform.position);

//        transform.LookAt(player);

//        if (!alreadyAttacked)
//        {
//            //attack code here///////////////////////////////////////////////////
//            // rb.AddForce(transform.forward * 32, ForceMode.Impulse) for Big enemies so the push the player away!!

//            Rigidbody rb = Instantiate(Sharpnell, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

//            rb.AddForce(transform.forward * 16, ForceMode.Impulse);

//            // rb.AddForce(transform.up * 8, ForceMode.Impulse);
//            /////////////////////////////////////////////////////////////////////
//            alreadyAttacked = true;
//            Invoke(nameof(ResetAttack), timeBetweenAttacks);
//        }
//    }
//    private void ResetAttack()
//    {
//        alreadyAttacked = false;
//    }

//    //private int FindSharpnell() 
//    //{
//    //    for (int i = 0; i < Sharpnell.Length; i++) 
//    //    {
//    //        if (!Sharpnell[i].activeInHierarchy) 
//    //        {
//    //            return i;
//    //        }
//    //    }
//    //    return 0;
//    //}
//    private void Update()
//    {
//        cooldownTimer += Time.deltaTime;

//        if (cooldownTimer >= attackCooldown) 
//            Attack();

//    }
//}
