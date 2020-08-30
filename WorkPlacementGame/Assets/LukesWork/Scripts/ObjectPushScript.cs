using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushScript : MonoBehaviour
{
    Vector3 vec, pos;
    RaycastHit hit, hit2;
    public bool move = true, cantMove = false;
    public GameObject obj;
    Collider col;
    ParticleSystem smoke;

    void Update()
    {
        vec = transform.rotation.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f);
        col = hit.collider;

        if (col != null && col.CompareTag("Grab"))
            if (Input.GetKeyDown(KeyCode.E) && move)
            {
                obj = GetObject();
                pos = GetPosition();

                cantMove = Physics.Raycast(GetObject().transform.position, GetPosition(), out hit2, 1f);

                move = false;

                //smoke = obj.GetComponentInChildren<ParticleSystem>();

                //if (smoke.isStopped)
                //{
                //    smoke.Play();
                //}
            }

        if (obj != null && cantMove == false)
            obj.transform.position = Vector3.Lerp(
                obj.transform.position, pos, 5 * Time.deltaTime);

        Invoke("StopMoving", 3f);
    }

    void MoveToPosition()
    {
        //hit.collider.gameObject.transform.position = transform.position + (dir * 5);
        pos = GetPosition();
    }

    GameObject GetObject()
    {
        return hit.collider.gameObject;
    }

    Vector3 GetPosition()
    {
        var dir = Quaternion.Euler(vec) * Vector3.forward;

        return obj.transform.position + (dir * 5);
    }

    void StopMoving()
    {
        obj = null;
        move = true;
        CancelInvoke();
    }
}
