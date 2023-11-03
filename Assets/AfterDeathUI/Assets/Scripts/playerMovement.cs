using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float positionX;
    public Animator animator;
    float positionY;
    public GameObject blackoutImage;
    void Start()
    {
        //startY =  5.97f
        //finalY = -2.26f
        positionX = -1.5f;
        positionY = 5.97f;
        animator.SetBool("isFallingEnded", false);
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    animator.SetBool("isWalking", true);
        //    positionX += 0.02f;
        //    gameObject.transform.position = new Vector3(positionX, -3.28f);
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //}

        if (positionY > -2.255014f)
        {
            gameObject.transform.position = new Vector3(-1.15f, positionY);
            positionY -= 0.1f;
        }
        if (positionY <= -1.5f && positionX < 0.3f)
        {
            animator.SetBool("isFallingEnded", true);
            gameObject.transform.position = new Vector3(positionX, positionY);
            positionX += 0.03f;
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
        StartCoroutine(Blackout());
    }
    IEnumerator Blackout()
    {
        yield return new WaitForSeconds(3.5f);
        blackoutImage.SetActive(true);
    }
}
