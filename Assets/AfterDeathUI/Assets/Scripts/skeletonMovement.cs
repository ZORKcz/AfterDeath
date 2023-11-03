using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonMovement : MonoBehaviour
{
    public static float positionX;
    public GameObject skeletonDeath;
    public GameObject alfaBoard;
    public GameObject mainMenuSoundtrack;
    void Start()
    {
        positionX = -7.13f;
        alfaBoard.SetActive(false);
        skeletonDeath.SetActive(false);
        gameObject.SetActive(true);
        StartCoroutine(ChuzeSkeleton());
    }
    IEnumerator ChuzeSkeleton()
    {
        while (positionX <= -3.64)
        {
            gameObject.transform.position = new Vector3(positionX, -3.08f);
            yield return new WaitForSeconds(0.05f);
            positionX += 0.1f;
        }
        if (positionX >= -3.7f)
        {
            gameObject.SetActive(false);
            positionX = -7.31f;
            skeletonDeath.SetActive(true);
            alfaBoard.SetActive(true);
            mainMenuSoundtrack.SetActive(true);
        }
    }
}
