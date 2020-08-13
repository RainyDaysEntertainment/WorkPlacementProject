using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExclamationScript : MonoBehaviour
{
    Camera cam;
    GameObject image;

    void Start()
    {
        image = GetComponentInChildren<Image>().gameObject;
        image.SetActive(false);
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        gameObject.transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
            cam.transform.rotation * Vector3.up);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pickup"))
            image.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
            image.SetActive(false);
    }
}
