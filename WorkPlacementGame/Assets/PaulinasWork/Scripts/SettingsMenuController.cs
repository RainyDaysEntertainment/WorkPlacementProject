using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject mainMenu;
    public Button backBtn;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
