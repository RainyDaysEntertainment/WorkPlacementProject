using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuTrigger : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;

    private void Start()
    {
        //pausePanel = GameObject.Find("PauseMenu");
        //settingsPanel = GameObject.Find("settingsMenu");
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = pausePanel.activeSelf;
            pausePanel.SetActive(!isActive);
        }

        bool a = pausePanel.activeSelf;
        if(a==false)
        {
            Time.timeScale = 1;
        }

    }
}
