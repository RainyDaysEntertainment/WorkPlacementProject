using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAI : MonoBehaviour
{
    public float speed, moveTime, pauseTime, startMoveTime, startPauseTime, lerpSpeed, randomChangeDirection, startRandomChangeDirection;
    public Transform[] pathPoints;
    public int randomPoint;
    public GameObject pathParent;

    Vector3 moveTo;

    public Animator anim;

    void Start()
    {
        moveTime = startMoveTime;
        speed = Random.Range(1.2f, 2.5f);
        pauseTime = 1;

        anim = transform.GetComponentInChildren<Animator>();

        pathParent = GameObject.Find("PathPoints");

        for (int i = 0; i < pathParent.transform.childCount; i++)
        {
            pathPoints[i] = pathParent.transform.GetChild(i);
        }

        //InvokeRepeating("FindOtherNPCs", 0, 0.1f);
    }

    void Update()
    {
        moveTime -= Time.deltaTime;
        randomChangeDirection -= Time.deltaTime;

        if (randomChangeDirection < 0)
        {
            int r = randomPoint;
            int p = Random.Range(0, 2) * 2 - 1;
            randomPoint = r + p;

            startRandomChangeDirection = Random.Range(45, 360);

            randomChangeDirection = startRandomChangeDirection;
        }

        if (moveTime > 0)
        {
            anim.SetBool("isWalking", true);

            moveTo = Vector3.LerpUnclamped(transform.position, pathPoints[randomPoint].position, lerpSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);

            var rot = Quaternion.LookRotation((transform.position - pathPoints[randomPoint].position).normalized);
            rot *= Quaternion.Euler(-90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                rot, 0.08f);

            if (Vector3.Distance(transform.position, pathPoints[randomPoint].position) < 0.25f)
            {
                int r = randomPoint;
                int p = Random.Range(0, 2) * 2 - 1;
                randomPoint = r + p;
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
            pauseTime -= Time.deltaTime;

            if (pauseTime <= 0)
            {
                moveTime = Random.Range(3, 240);
                speed = Random.Range(1.2f, 2.5f);
                startPauseTime = Random.Range(20, 80);

                int r = randomPoint;
                int p = Random.Range(0, 2) * 2 - 1;
                randomPoint = r + p;

                pauseTime = startPauseTime;
            }
        }

        if (randomPoint <= 0)
            randomPoint = pathPoints.Length - 1;

        if (randomPoint == pathPoints.Length)
            randomPoint = 0;
    }

    void FindOtherNPCs()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (Vector3.Distance(transform.position, g.transform.position) < 2f)
            {
                //transform.position = Vector3.MoveTowards(transform.position, transform.position - g.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
