using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovementP : MonoBehaviour
{
    private float movementSpeed;
    void Start()
    {
        movementSpeed = 10f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        { transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f; }
        else if (Input.GetKey(KeyCode.W))
        { transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed; }
        else if (Input.GetKey(KeyCode.S))
        { transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed; }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        { transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed; }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        { transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed; }

    }
}
