using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f, timeLeft = 1, timeReset = 1;
    public LayerMask enemyLayers;
    bool countdown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            countdown = true;
        }

        if (countdown)
        {
            timeLeft -= Time.deltaTime;
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (timeLeft < 0)
                {
                    RangedAttack();
                }
                else
                {
                    Attack();
                }

                countdown = false;
                timeLeft = timeReset;
            }
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Sword hit " + enemy.name);
        }
    }

    private void RangedAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Ranged hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
