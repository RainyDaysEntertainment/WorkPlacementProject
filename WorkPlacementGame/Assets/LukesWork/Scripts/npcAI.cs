using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAI : MonoBehaviour
{
    public float speed, moveTime, pauseTime, startPauseTime, lerpSpeed, lastDis = 100;
    public Transform[] pathPoints;
    public int randomPoint;
    public GameObject pathParent;
    Vector3 moveTo;

    public Animator anim;

    void Start()
    {
        speed = Random.Range(0.5f, 1.9f);
        pauseTime = 0;

        anim = transform.GetComponentInChildren<Animator>();

        pathParent = GameObject.Find("PathPoints");

        pathPoints = new Transform[pathParent.transform.childCount];

        for (int i = 0; i < pathParent.transform.childCount; i++)
        {
            pathPoints[i] = pathParent.transform.GetChild(i);
        }

        //InvokeRepeating("FindOtherNPCs", 0, 0.1f);
    }

    void Update()
    {
        if (randomPoint == 0)
        {
            randomPoint = FindInitialPoint();
        }

        moveTime -= Time.deltaTime;

        if (moveTime > 0)
        {
            anim.SetBool("isWalking", true);
            anim.speed = Random.Range(0.4f, 1.6f);

            moveTo = Vector3.LerpUnclamped(transform.position, pathPoints[randomPoint].position, lerpSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);

            var rot = Quaternion.LookRotation((transform.position - pathPoints[randomPoint].position).normalized);
            rot *= Quaternion.Euler(-90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                rot, 0.08f);

            if (Vector3.Distance(transform.position, pathPoints[randomPoint].position) < 0.75f)
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
                moveTime = Random.Range(3.5f, 60.5f);
                speed = Random.Range(0.5f, 1.9f);
                startPauseTime = Random.Range(10.5f, 60.5f);

                //int r = randomPoint;
                //int p = Random.Range(0, 2) * 2 - 1;
                //randomPoint = r + p;

                pauseTime = startPauseTime;
            }
        }

        if (randomPoint < 1)
            randomPoint = pathPoints.Length - 1;

        if (randomPoint == pathPoints.Length)
            randomPoint = 0;
    }

    //void FindOtherNPCs()
    //{
    //    foreach (GameObject g in GameObject.FindGameObjectsWithTag("NPC"))
    //    {
    //        if (Vector3.Distance(transform.position, g.transform.position) < 2f)
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, transform.position - g.transform.position, speed * Time.deltaTime);
    //        }
    //    }
    //}

    int FindInitialPoint()
    {
        int closest = 30;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            Vector3 distance = pathPoints[i].transform.position - transform.position;
            float curDistance = distance.sqrMagnitude;

            if (curDistance < lastDis)
            {
                closest = i;
                lastDis = curDistance;
            }
        }

        return closest;
    }
}
