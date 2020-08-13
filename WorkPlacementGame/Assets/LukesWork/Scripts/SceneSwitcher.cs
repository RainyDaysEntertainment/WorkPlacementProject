using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public int levelNum = 2;
    public Vector3 position;
    public GameObject player;
    OnSceneLoad onLoad;

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    LoadScene();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneIEnum(levelNum));
    }

    IEnumerator LoadSceneIEnum(int levelNumber)
    {
        transition.SetTrigger("Start");

        onLoad.position = position;
        GameObject.Find("Player").GetComponent<OnSceneLoad>().position = onLoad.position;

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Player Scene", LoadSceneMode.Single);
        SceneManager.LoadScene(levelNumber, LoadSceneMode.Additive);
    }

    GameObject GetPlayer()
    {
        return GameObject.Find("Player");
    }
}
