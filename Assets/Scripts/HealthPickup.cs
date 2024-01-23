using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 25;
    public float floatSpeed = 2.5f;  //Rychlost citronu
    public float floatDistance = 0.3f;  //Vzdalenost nahoru

    AudioSource pickupSource;

    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable) 
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if(wasHealed)
            {
                if(pickupSource)
                {
                    AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
                    Destroy(gameObject);
                }
            }
        } 
    }

    private void Update()
    {
        float yMove = Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + yMove, Time.deltaTime), transform.position.z);
    }

}
