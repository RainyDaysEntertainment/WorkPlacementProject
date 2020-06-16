using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraScript : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.down);
    }
}
