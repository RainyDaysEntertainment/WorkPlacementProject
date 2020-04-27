using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;
    Toggle fullscreenToggle;
    Dropdown resolutionDropdown;
    Slider brightnessSlider;
    AudioSource audioSource;

    public void Back()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ResetChanges()
    {

    }

    public void FullScreen(bool fullscreen)
    {
        if (fullscreen == true)
        {
            Screen.fullScreen = true;
        }
        else
            Screen.fullScreen = false;
    }

    public void Resolution(Text res)
    {
        if (res.text.ToString() == "640x480")
        {
            Screen.SetResolution(640, 480, false);
        }
        if (res.text.ToString()=="1920x1080")
        {
            Screen.SetResolution(1920, 1080, false);
        }
        if (res.text.ToString() == "1280x720")
        {
            Screen.SetResolution(1280, 720, false);
        }
        if (res.text.ToString() == "1024x768")
        {
            Screen.SetResolution(1024, 720, false);
        }
        if (res.text.ToString() == "800x600")
        {
            Screen.SetResolution(800, 600, false);
        }
    }

    public void Quality(Text quality)
    {
        if(quality.text.ToString()=="High")
        {
            QualitySettings.SetQualityLevel(4,true);
            Debug.Log("quality changed to high");
        }
        if (quality.text.ToString() == "Medium")
        {
            QualitySettings.SetQualityLevel(3, true);
            Debug.Log("quality changed to medium");
        }
        if (quality.text.ToString() == "Low")
        {
            QualitySettings.SetQualityLevel(2, true);
            Debug.Log("quality changed to low");
        }
    }

    public void Brightness(float newVal)
    {
        Screen.brightness = newVal;
    }

    public void Volume(float newVal)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = newVal;
    }

    public void FrameRate(Text fr)
    {
        if(fr.text.ToString()=="30")
        {
            Application.targetFrameRate = 30;
        }
        if (fr.text.ToString() == "60")
        {
            Application.targetFrameRate = 60;
        }
        if (fr.text.ToString() == "Unlimited")
        {
            Application.targetFrameRate = 300;
        }
    }
}
