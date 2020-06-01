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

    public void Settings()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
