using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    private Button continueBtn;
    private Button settingsBtn;
    private Button mainMenuBtn;
    private Button quitBtn;
    public GameObject settingsMenu;
    private GameObject pauseMenu;

    public void Start()
    {
        continueBtn = GameObject.Find("btnContinue").GetComponent<Button>();
        settingsBtn = GameObject.Find("btnSettings").GetComponent<Button>();
        mainMenuBtn = GameObject.Find("btnMainMenu").GetComponent<Button>();
        quitBtn = GameObject.Find("btnQuit").GetComponent<Button>();

        //settingsMenu = GameObject.Find("settingsMenu");
        pauseMenu = GameObject.Find("PauseMenu");

        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0;
    }


    public void Settings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
