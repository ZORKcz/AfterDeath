using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;
public class arrowScript : MonoBehaviour
{
    public TMP_Text currentArrowCount;
    //Potøebný script
    public PlayerController playerControllerScript;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentArrowCount.text = playerControllerScript.maxArrows + "/6";
    }

    void Update()
    {
        currentArrowCount.text = playerControllerScript.currentArrows + "/6";
        if (playerControllerScript.currentArrows == 0 && Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("animaceArrowCount",0,0);
        }
    }
}
