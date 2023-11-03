using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class programCrashersLogoShowcase : MonoBehaviour
{
    public GameObject[] menuItems;
    public GameObject programCrashersLogo;
    void Start()
    {
        StartCoroutine(ProgramCrashersLogoShowcase());
    }
    IEnumerator ProgramCrashersLogoShowcase()
    {
        yield return new WaitForSeconds(5.1f);
        programCrashersLogo.SetActive(false);
        foreach(GameObject menuObject in menuItems)
        {
            menuObject.SetActive(true);
        }
    }
}
