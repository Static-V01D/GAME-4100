using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  // public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Play Attack animation

        ////////// animator.SetTrigger("Attack");\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        //Dettect enemies in range

       Collider[] hitenemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);



        //Damage them

        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<Enemy_States>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
