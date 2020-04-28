using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float speed = 6;
    public bool onGround;
    Vector3 moveDirection;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if (onGround)
        {
            rb.AddForce(Physics.gravity * rb.mass * 0.25f);
            rb.useGravity = false;
        }
        else
        {
            rb.AddForce(Physics.gravity * rb.mass);
            rb.useGravity = false;
        }

        transform.rotation = Quaternion.LookRotation(movement);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce((Vector3.up * 6000) + (transform.TransformDirection(Vector3.forward) * 1000));
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.1f))
        //Physics.Raycast(transform.position + (transform.TransformDirection(Vector3.forward) / 2), transform.TransformDirection(Vector3.down) + (transform.TransformDirection(Vector3.forward) / 2), out hit, 1.5f))
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.right), out hit, 2.2f) &&
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.left), out hit, 2.2f))
        {
            onGround = true;
        }
        else
        {
            //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit2, Mathf.Infinity);
            //var distanceToGround = hit2.distance;
            //transform.position = new Vector3(transform.position.x, distanceToGround/* + transform.GetComponent<Collider>().bounds.extents.y*/, transform.position.z);

            onGround = false;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.1f, Color.yellow);
        Debug.DrawRay(transform.position + (transform.TransformDirection(Vector3.forward) / 2), (transform.TransformDirection(Vector3.down)/* + transform.TransformDirection(Vector3.forward) / 2*/) * 1.7f, Color.yellow);
    }
}
