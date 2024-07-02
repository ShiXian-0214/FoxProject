using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;   // get the all resolutions of the screen and store them in array

        resolutionDropdown.ClearOptions();  // clear the default options of the array

        List<string> options = new List<string>();

        int currentresolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) // identify the default resolution of the current system.
            {
                currentresolution = i;
            }
        }

        resolutionDropdown.AddOptions(options); /* create a dropdown list, add Screen.resolutions to the dropdown list. 
                                                 Nonetheless, .AddOptions() takes a list of STRING in stead of ARRAY and consequently Line 20 ~ 26 convert the array of 
                                                 resolution to a list of string. */
        resolutionDropdown.value = currentresolution;   // select the value of default resolution 
        resolutionDropdown.RefreshShownValue(); // show the default resolution
    }

    // Update resolution
    public void resolution_setting(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Audio
    public void main_volume(float volume)
    {
        mixer.SetFloat("Main", volume);
    }

    public void prelude_volume(float volume)
    {
        mixer.SetFloat("Prelude", volume);
    }

    // Graphic
    public void graphic_setting(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    //FullScreen
    public void fullscreen_setting(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
