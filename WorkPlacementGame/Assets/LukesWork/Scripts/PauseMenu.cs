using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool menuActive = false;
    public Animator transition;
    SceneAdder adder;

    void Start()
    {
        pauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        pauseMenu.SetActive(menuActive);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActive = !menuActive;
        }

        if (menuActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuEnum());
    }

    public IEnumerator MainMenuEnum()
    {
        menuActive = false;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name != "Player Scene")
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        SceneManager.LoadScene(0, LoadSceneMode.Additive);

        transition.ResetTrigger("Start");
        transition.ResetTrigger("End");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
