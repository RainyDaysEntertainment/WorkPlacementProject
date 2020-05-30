using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float speed;
    public bool onGround;
    public Vector3 moveDirection;
    Vector3 movement;
    DialogueManagerScript dialogue;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        dialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManagerScript>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
        
        if (dialogue.statementEndBool == true)
        {
            rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));

            if (movement != Vector3.zero)
            {
                //transform.rotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(movement.normalized), 0.2f);
            }
        }

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce((Vector3.up * 6000) + (transform.TransformDirection(Vector3.forward) * 1000));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            speed = 1;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            speed = 6;
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
