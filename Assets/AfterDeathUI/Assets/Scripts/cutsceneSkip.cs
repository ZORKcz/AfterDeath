using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cutsceneSkip : MonoBehaviour
{

    void Update()
    {
        if (CanvasScript.jeMozneSkipnoutCutscenu && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}
