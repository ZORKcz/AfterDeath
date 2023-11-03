using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public GameObject[] UIElementsHlavniMenu;
    public GameObject[] UIElementsSettingsMenu;
    public GameObject skeletonRemains;
    public GameObject skeleton;
    public GameObject mainMenuSoundtrack;
    public GameObject videoPlayer;
    public GameObject videoRenderer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnSettingsClick()
    {
        skeleton.SetActive(false);
        skeletonRemains.transform.position = new Vector3(-20f, -3.06f);
        foreach(GameObject UIElement in UIElementsHlavniMenu)
        {
            UIElement.SetActive(false);
        }
        foreach (GameObject UIElement in UIElementsSettingsMenu)
        {
            UIElement.SetActive(true);
        }
    }
    public void OnBackClick()
    {
        mainMenuSoundtrack.SetActive(true);
        skeletonRemains.SetActive(true);
        skeletonRemains.transform.position = new Vector3(-3.7f, -3.75f);
        foreach (GameObject UIElement in UIElementsHlavniMenu)
        {
            UIElement.SetActive(true);
        }
        foreach (GameObject UIElement in UIElementsSettingsMenu)
        {
            UIElement.SetActive(false);
        }
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        foreach (GameObject UIElement in UIElementsHlavniMenu)
        {
            UIElement.SetActive(true);
        }
        mainMenuSoundtrack.SetActive(false);
        skeletonRemains.SetActive(false);
        videoPlayer.SetActive(true);
        videoRenderer.SetActive(true);
        StartCoroutine(waitTillVideoEnds());
    }

    IEnumerator waitTillVideoEnds()
    {
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene(1);
    }
}
