using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public GameObject[] pauseMenu;
    public GameObject[] settingsMenu;
    public GameObject menuPauseMenuBackGround;
    public bool timeHasBeenStopped;
    public bool pauseMenuHasBeenActivated;
    void Start()
    {
        pauseMenuHasBeenActivated = true;
        timeHasBeenStopped = false;    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !deathMenuScript.isDead)
        {
            if (pauseMenuHasBeenActivated)
            {
                menuPauseMenuBackGround.SetActive(true);
                foreach (GameObject uiElement in pauseMenu)
                {
                    uiElement.SetActive(true);
                }
                pauseMenuHasBeenActivated = false;
            }
            else
            {
                menuPauseMenuBackGround.SetActive(false);
                foreach (GameObject uiElement in pauseMenu)
                {
                    uiElement.SetActive(false);
                }
                pauseMenuHasBeenActivated = true;
            }
            timeHasBeenStopped = !timeHasBeenStopped;
            if (timeHasBeenStopped)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            foreach (GameObject uiSettingsElements in settingsMenu)
            {
                uiSettingsElements.SetActive(false);
            }

        }
    }

    public void OnSettingsButtonClick()
    {
        foreach(GameObject uiSettingsElements in settingsMenu)
        {
            uiSettingsElements.SetActive(true);
        }
        foreach (GameObject uiElement in pauseMenu)
        {
            uiElement.SetActive(false);
        }
    }
    
    public void OnBackButtonClick()
    {
        foreach (GameObject uiSettingsElements in settingsMenu)
        {
            uiSettingsElements.SetActive(false);
        }
        foreach (GameObject uiElement in pauseMenu)
        {
            uiElement.SetActive(true);
        }
    }

    public void OnResumeButtonClick()
    {
        menuPauseMenuBackGround.SetActive(false);
        foreach (GameObject uiElement in pauseMenu)
        {
            uiElement.SetActive(false);
        }
        pauseMenuHasBeenActivated = true;
        timeHasBeenStopped = false;
        Time.timeScale = 1;
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
