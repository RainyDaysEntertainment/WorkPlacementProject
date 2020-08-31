﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public Vector3 position;
    public GameObject cam;

    public float radius = 2f, dis;

    private void Start()
    {
        InvokeRepeating("Check", 0, 1.1f);
    }

    IEnumerator LoadSceneIEnum(int levelNumber)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        cam.SetActive(false);

        if (levelNumber == 2)
        {
            cam.SetActive(true);
        }

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name != "Player Scene")
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        SceneManager.LoadScene(levelNumber, LoadSceneMode.Additive);

        transform.position = position;

        transition.ResetTrigger("Start");
        transition.ResetTrigger("End");
    }

    void Check()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SceneSwitcher"))
        {
            dis = Vector3.Distance(g.transform.position, gameObject.transform.position);

            if (dis <= radius)
            {
                StartCoroutine(LoadSceneIEnum(g.gameObject.GetComponent<SceneNum>().sceneNumber));
                position = g.gameObject.GetComponent<SceneNum>().position;
            }
        }
    }
}
