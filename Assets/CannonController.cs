using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bullet;
    float timeBetween;
    public float startTimeBetween;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetween <= 0)
        {
            GameObject bulletPrefab = Instantiate(bullet, firepoint.position, firepoint.rotation);
            timeBetween = startTimeBetween;

            Destroy(bulletPrefab, 20f);
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
