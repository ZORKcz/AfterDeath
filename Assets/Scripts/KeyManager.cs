using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool isPickedUp;
    private Vector2 velocity;
    public float smoothTime;
    public float floatSpeed = 2.5f;  //Rychlost citronu
    public float floatDistance = 0.3f;  //Vzdalenost nahoru

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothTime);
        }
        else
        {
            float yMove = Mathf.Sin(Time.time * floatSpeed) * floatDistance;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + yMove, Time.deltaTime), transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
        }
    }
}
