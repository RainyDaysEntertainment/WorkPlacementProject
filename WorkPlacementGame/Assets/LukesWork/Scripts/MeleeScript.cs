using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f, timeLeft = 1, timeReset = 1, knockbackStrength = 5;
    public LayerMask enemyLayers;
    public bool countdown = false, melee, range;
    public GameObject projectile, playerObj;
    private PlayerMovementScript player;
    private ParticleSystem particles;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        playerObj = GameObject.Find("Player");
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            countdown = true;
        }

        if (countdown)
        {
            timeLeft -= Time.deltaTime;

            if (!particles.isPlaying)
                particles.Play();

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                particles.Stop();

                if (timeLeft < 0)
                {
                    RangedAttack();
                    particles.Stop();
                }
                else
                {
                    Attack();
                }

                countdown = false;
                timeLeft = timeReset;
            }
        }

        if (timeLeft < 0)
        {
            particles.Stop();
        }
        else
        {
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 dir = enemy.transform.position - transform.position;

                //rb.AddForce(dir.normalized * knockbackStrength + new Vector3(1, 10, 1), ForceMode.Impulse);
                rb.AddExplosionForce(knockbackStrength, transform.position, attackRange, 2.5f, ForceMode.Impulse);

                Debug.Log("AAAAAAAAA");
            }
        }
    }

    private void RangedAttack()
    {
        GameObject chargeShot = Instantiate(projectile, attackPoint.position - new Vector3(0, 1, 0), Quaternion.identity);
        Rigidbody rb = chargeShot.GetComponent<Rigidbody>();
        rb.AddForce((playerObj.transform.forward * 10), ForceMode.Impulse);
        chargeShot.transform.rotation = playerObj.transform.rotation;
        Destroy(chargeShot, 5f);
        //chargeShot.transform.position = player.moveDirection;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
