using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public Vector3 position;
    public GameObject clouds, filter, cam;

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    LoadScene();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SceneSwitcher"))
        {
            StartCoroutine(LoadSceneIEnum(other.gameObject.GetComponent<SceneNum>().sceneNumber));
            position = other.gameObject.GetComponent<SceneNum>().position;
        }
    }

    IEnumerator LoadSceneIEnum(int levelNumber)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        cam.SetActive(false);
        //clouds.SetActive(false);
        //filter.SetActive(false);

        if (levelNumber == 2)
        {
            cam.SetActive(true);
            //clouds.SetActive(true);
            //filter.SetActive(true);
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
    }
}
