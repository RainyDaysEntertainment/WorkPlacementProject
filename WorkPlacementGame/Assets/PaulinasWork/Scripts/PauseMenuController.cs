using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button continueBtn;
    public Button settingsBtn;
    public Button mainMenuBtn;
    public Button quitBtn;
    public Canvas Canvas;
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    public void Start()
    {
        pauseMenu.SetActive(true);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Continue()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("PaulinasWork/Scenes/MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
