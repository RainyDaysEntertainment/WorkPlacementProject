using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float speed = 6;
    //public LeanTweenType jumpType;
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
            rb.AddForce((Vector3.up * 10000) + (transform.TransformDirection(Vector3.forward) * 2000));
            //LeanTween.moveY(gameObject, gameObject.transform.position.y + 3f, 0.3f).setEase(jumpType).setLoopPingPong(1);
            //LeanTween.moveY(gameObject, gameObject.transform.position.y, 0.3f).setDelay(0.3f).setEase(jumpType);
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

        if (onGround)
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, hit.transform.position.y + gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.1f, Color.yellow);
        Debug.DrawRay(transform.position + (transform.TransformDirection(Vector3.forward) / 2), (transform.TransformDirection(Vector3.down)/* + transform.TransformDirection(Vector3.forward) / 2*/) * 1.7f, Color.yellow);
    }
}
