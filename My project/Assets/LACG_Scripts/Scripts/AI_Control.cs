using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI_Control : MonoBehaviour
{
    private GameObject[] goalLocations;
    private NavMeshAgent agent;
    private Animator anim;
    float speedMultiplier;
    private float detectionRadius = 20f;
    private float fleeRadius = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       // anim = GetComponent<Animator>();
        goalLocations = GameObject.FindGameObjectsWithTag("Goal");
        int i = Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[i].transform.position);
      //  anim.SetTrigger("isWalking");
      //  anim.SetFloat("Offset", Random.Range(0f, 1f));
        ResetAgent();
    }

    private void ResetAgent()
    {
        float speedMultiplier = Random.Range(0.5f, 1.2f);
      //  anim.SetFloat("Speed", speedMultiplier);
        agent.speed *= speedMultiplier;
      //  anim.SetTrigger("isWalking");
        agent.angularSpeed = 120f;
        agent.ResetPath();
    }

    public void DetectNewObstacle(Vector3 position)
    {
        if(Vector3.Distance(position, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - position).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if(path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 5f;
                agent.angularSpeed = 500f;
            }
        }
    }

    private void Update()
    {
        if(agent.remainingDistance <= 1)
        {
            ResetAgent();
            int i = Random.Range(0, goalLocations.Length);
            agent.SetDestination(goalLocations[i].transform.position);
        }
    }


}
