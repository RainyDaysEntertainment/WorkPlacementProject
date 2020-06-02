using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float speed = 5, dis = 5;
    Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = dis;
        
        Vector3 mouseScreenToWorld = cam.ScreenToWorldPoint(mousePos);
        Vector3 pos = Vector3.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));

        transform.position = pos;
    }
}
