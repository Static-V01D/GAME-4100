using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class Enemy_States : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, WhatIsPlayer;

    public float Health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject bullet;

    public Transform EnemyAttackPoint;   
    public LayerMask PlayerLayers;
    public int attackDamage = 400;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {

        player = GameObject.Find("PlayerArmature").transform;  // Tests are being made so it is called PlayerArmature to use that model//
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    { 


        //Check for range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();        

    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {

        //Calculate random point in it's range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move while attacking
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            /*
            //attack code here///////////////////////////////////////////////////
            // rb.AddForce(transform.forward * 32, ForceMode.Impulse) for Big enemies so the push the player away!!

            Rigidbody rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 16, ForceMode.Impulse);

           // rb.AddForce(transform.up * 8, ForceMode.Impulse);
            ///////////////////////////////////////////////////////////////////// */
            ///

            Collider[] hitenemies = Physics.OverlapSphere(EnemyAttackPoint.position, attackRange, PlayerLayers);



            //Damage them

            foreach (Collider enemy in hitenemies)
            {
                enemy.GetComponent<Playerhealth>().TakeDamage(5);
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked= false;
    }    

    //Vida del enemigo
   public  void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health <= 0) Invoke(nameof(DestroyEnemy), .5f);
        
        
    }

     void DestroyEnemy()
    {
        //Debug.Log("Enemy died!!!");
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
