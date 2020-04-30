using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGrabScript : MonoBehaviour
{
    public bool grabbing;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && grabbing)
        {
            grabbing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            if (Input.GetKeyDown(KeyCode.E))
                grabbing = true;
        }
    }
}
