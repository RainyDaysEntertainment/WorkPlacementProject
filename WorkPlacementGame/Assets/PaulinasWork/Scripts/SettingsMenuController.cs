using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;

    public Button applyChangesBtn;

    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown frameRateDropdown;
    public Slider brightnessSlider;
    public Slider audioSlider;
    public AudioMixer audioMixer;

    public MainMenuUIMove mainMenuUI;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        int current = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                current = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = current;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Back()
    {
        LeanTween.moveX(mainMenuUI.menu, Screen.width / 2, 2).setEase(mainMenuUI.easeType);
    }

    public void ResetChanges()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        resolutionDropdown.value = resolutions.Length;
        fullscreenToggle.isOn = false;

        Screen.brightness = 0.5f;
        brightnessSlider.value = 0.5f;

        QualitySettings.SetQualityLevel(3, true);
        qualityDropdown.value = 3;

        Application.targetFrameRate = 60;
        frameRateDropdown.value = 5;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void FullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void Quality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void Brightness(float newVal)
    {
        Screen.brightness = newVal;
    }

    public void Volume(float newVal)
    {
        audioMixer.SetFloat("volume", newVal);
    }

    public void FrameRate(TMP_Text fr)
    {
        if (fr.text.ToString() == "30")
        {
            Application.targetFrameRate = 30;
        }
        if (fr.text.ToString() == "60")
        {
            Application.targetFrameRate = 60;
        }
        if (fr.text.ToString() == "75")
        {
            Application.targetFrameRate = 75;
        }
        if (fr.text.ToString() == "120")
        {
            Application.targetFrameRate = 120;
        }
        if (fr.text.ToString() == "Unlimited")
        {
            Application.targetFrameRate = -1;
        }
    }
}
