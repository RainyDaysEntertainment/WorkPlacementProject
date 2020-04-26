using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTeleportationScript : MonoBehaviour
{
    public GameObject newHole;
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position == other.transform.position)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = newHole.transform.position;
        }
    }
}
