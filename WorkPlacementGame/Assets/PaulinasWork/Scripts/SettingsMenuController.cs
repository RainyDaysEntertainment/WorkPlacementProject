using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;

    public Button applyChangesBtn;

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown frameRateDropdown;
    public Slider brightnessSlider;
    public Slider audioSlider;
    AudioSource audioSource;
    

    public void Back()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ResetChanges()
    {
        Screen.SetResolution(1920, 1080, false);
        resolutionDropdown.value = 0;
        fullscreenToggle.isOn = false;

        Screen.brightness = 0.5f;
        brightnessSlider.value = 0.5f;

        QualitySettings.SetQualityLevel(4, true);
        qualityDropdown.value = 1;

        Application.targetFrameRate = 30;
        frameRateDropdown.value = 0;

        audioSource.volume = 1;
        audioSlider.value = 1;
    }

    public void FullScreen(bool fullscreen)
    {

        if (fullscreen == true)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

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
        if (res.text.ToString() == "2560x1440")
        {
            Screen.SetResolution(2560, 1440, false);
        }
        if (res.text.ToString() == "3840x2160")
        {
            Screen.SetResolution(3840, 2160, false);
        }

        //PlayerPrefs.SetInt(res.text.ToString(), resolutionDropdown.value) ;
        //PlayerPrefs.Save();
    }

    public void Quality(Text quality)
    {
        if (quality.text.ToString() == "Very High")
        {
            QualitySettings.SetQualityLevel(5, true);
        }
        if (quality.text.ToString()=="High")
        {
            QualitySettings.SetQualityLevel(4,true);
        }
        if (quality.text.ToString() == "Medium")
        {
            QualitySettings.SetQualityLevel(3, true);
        }
        if (quality.text.ToString() == "Low")
        {
            QualitySettings.SetQualityLevel(2, true);
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
        if (fr.text.ToString() == "75")
        {
            Application.targetFrameRate = 75;
        }
        if (fr.text.ToString() == "90")
        {
            Application.targetFrameRate = 90;
        }
        if (fr.text.ToString() == "120")
        {
            Application.targetFrameRate = 120;
        }
        if (fr.text.ToString() == "240")
        {
            Application.targetFrameRate = 240;
        }
    }
}
