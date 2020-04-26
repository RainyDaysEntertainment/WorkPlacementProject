﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float speed = 10;
    //public LeanTweenType jumpType;
    public bool onGround, canMove;
    Vector3 moveDirection;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

            rb.MovePosition(transform.position + movement);
        }
    }

    private void Update()
    {
        Quaternion tr = Quaternion.LookRotation(transform.forward);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * 1000);
        transform.rotation = targetRotation;

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //rb.AddForce(Vector3.up * 1000);
            //LeanTween.moveY(gameObject, gameObject.transform.position.y + 3f, 0.3f).setEase(jumpType).setLoopPingPong(1);
            //LeanTween.moveY(gameObject, gameObject.transform.position.y, 0.3f).setDelay(0.3f).setEase(jumpType);
        }

        RaycastHit hit;

        if (/*Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.1f) ||*/ 
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.forward), out hit, 1.8f) &&
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.right), out hit, 1.8f) &&
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.left), out hit, 1.8f))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        if (onGround)
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, hit.transform.position.y + gameObject.transform.position.y, gameObject.transform.position.z);
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
        Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.forward)) * 1.8f, Color.yellow);
    }
}
