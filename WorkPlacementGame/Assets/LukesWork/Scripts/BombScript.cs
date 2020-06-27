using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float knockbackStrength, knockbackRadius;
    private MeleeScript melee;
    public LayerMask enemyLayers;
    public GameObject bomb, obj;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            obj = Instantiate(bomb, gameObject.transform.position - new Vector3(0, 0.5f, 0), Quaternion.Euler(-90, 180, 0));
            Invoke("Explode", 3);
            Destroy(obj, 3);
        }
    }

    void Explode()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(obj.transform.position, knockbackRadius, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(knockbackStrength, obj.transform.position + new Vector3(0, -1, 0), knockbackRadius, 2.5f, ForceMode.Impulse);
            }
        }

        //Destroy(gameObject);
    }
}
