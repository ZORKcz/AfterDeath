using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Collider2D colize = GetComponent<Collider2D>();
            colize.isTrigger = true;
            Sprite render = GetComponent<Sprite>();
            SpriteRenderer gameObject = GetComponent<SpriteRenderer>();
            gameObject.enabled = false;
        }
    }
}
