using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip2Setup : MonoBehaviour
{
    public GameObject slot2;
    public GameObject Icon;
    bool hover;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "climbingGear")
        {
            Destroy(other.gameObject);
        }
    }
}
