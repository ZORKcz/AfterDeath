using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixerMusic;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider volumeSliderMusic;
    public Slider sfxSlider;
    float currentVolume;
    float currentSFXVolume;
    Resolution[] resolutions;
    int currentRefreshRate;
    private List<Resolution> filteredResolutions;
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        filteredResolutions = new List<Resolution>();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0;i < resolutions.Length;i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        for (int i = 0; i < filteredResolutions.Count; i++)
        {

            string option = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz ";
            options.Add(option);
            if (filteredResolutions[i].width == Screen.currentResolution.width && filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixerMusic.SetFloat("Music", volume);
        //audioMixerMusic.SetFloat("sfx", volume);
        currentVolume = volume;
    }
    public void SetVolumeSFX(float volume)
    {
        audioMixerMusic.SetFloat("sfx", volume);
        currentSFXVolume = volume;
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreferences", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreferences", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreferences", currentVolume);
        PlayerPrefs.SetFloat("SFXPreferences", currentSFXVolume);
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreferences"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreferences");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
        if (PlayerPrefs.HasKey("FullscreenPreferences"))
        {
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreferences"));
        }
        else
        {
            Screen.fullScreen = true;
        }
        if (PlayerPrefs.HasKey("VolumePreferences"))
        {
            volumeSliderMusic.value = PlayerPrefs.GetFloat("VolumePreferences");
        }
        else
        {
            volumeSliderMusic.value = PlayerPrefs.GetFloat("VolumePreferences");
        }
        if (PlayerPrefs.HasKey("SFXPreferences"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXPreferences");
        }
        else
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXPreferences");
        }
    }
    public void DefaultSettings()
    {
        PlayerPrefs.DeleteAll();
    }
}
