using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip2Setup : MonoBehaviour
{
    GameObject slot2;
    GameObject Icon;
    bool hover;

    void Start()
    {
        slot2 = GameObject.Find("equip2");
        Icon = GameObject.Find("eq2img");
        Icon.SetActive(false);
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
