using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public Animator open;
    bool isOpen;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(OpenIEnum());
        }
    }
    IEnumerator OpenIEnum()
    {
        open.SetTrigger("Open");

        yield return new WaitForSeconds(3);

        open.SetTrigger("Close");
    }
}
