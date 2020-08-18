using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if (health >= 0)
        {
            //gameObject.Destroy(this);
        }
    }
}
