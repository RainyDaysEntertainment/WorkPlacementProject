using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button continueBtn;
    public Button newGameBtn;
    public Button settingsBtn;
    public Button quitBtn;
    public Canvas menuCanvas;

    public GameObject mainMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainScene/MainScene");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene/MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
