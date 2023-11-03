using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenuScript : MonoBehaviour
{

    public GameObject[] canvasItems;
    public Damageable health;
    public static bool isDead;
    void Start()
    {
        isDead = false;
        health.Health = 100;
    }

    void Update()
    {
        if (health.Health <= 0)
        {
            isDead = true;
            foreach(GameObject item in canvasItems)
            item.SetActive(true);
        }
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
