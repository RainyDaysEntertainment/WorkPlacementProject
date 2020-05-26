using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffectScript : MonoBehaviour
{
    public float knockbackStrength, knockbackRadius;
    private MeleeScript melee;
    public LayerMask enemyLayers;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, knockbackRadius, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(knockbackStrength, transform.position, knockbackRadius, 2.5f, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
