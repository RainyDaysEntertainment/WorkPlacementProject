using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFixMainMenu : MonoBehaviour
{
    public GameObject newGame, loadGame, settings, quit;
    public MainMenuUIMove menu;
    Vector3 newGamePos, loadGamePos, settingsPos, quitPos;

    private void Start()
    {
        newGamePos = newGame.transform.position;
        loadGamePos = loadGame.transform.position;
        settingsPos = settings.transform.position;
        quitPos = quit.transform.position;
    }

    void Update()
    {
        if (menu.settings)
        {
            newGame.transform.position = newGamePos;
            loadGame.transform.position = loadGamePos;
            settings.transform.position = settingsPos;
            quit.transform.position = quitPos;

            newGame.transform.position = new Vector3(newGame.transform.position.x + (Screen.width / 5.5f), newGame.transform.position.y, newGame.transform.position.z);
            loadGame.transform.position = new Vector3(loadGame.transform.position.x + (Screen.width / 5.5f), loadGame.transform.position.y, loadGame.transform.position.z);
            settings.transform.position = new Vector3(settings.transform.position.x + (Screen.width / 5.5f), settings.transform.position.y, settings.transform.position.z);
            quit.transform.position = new Vector3(quit.transform.position.x + (Screen.width / 5.5f), quit.transform.position.y, quit.transform.position.z);

            menu.settings = false;
        }
    }
}
