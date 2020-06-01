using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public int levelNum = 2;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            LoadScene();
        }
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

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelNumber);
        //SceneManager.LoadScene("Player Scene", LoadSceneMode.Additive);
    }
}
