using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        if (resolutionDropdown != null)
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + " hz";
                options.Add(option);

                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        FindObjectOfType<AudioManager>().StopPlaying("Corridor_Atmosphere");
        FindObjectOfType<AudioManager>().StopPlaying("StompRoom");
        FindObjectOfType<AudioManager>().StopPlaying("Inside_the_Tent");
        FindObjectOfType<AudioManager>().Play("mainmenuv2");
    }
}
