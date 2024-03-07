using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public int damage = 6;

    public Vector2 knockback = new Vector2(0, 0);

    Rigidbody2D rb;
    PolygonCollider2D polygonCollider2D;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent <PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();

            if (damageable != null) 
            {
                Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

                damageable.Hit(damage, deliveredKnockBack);
                Debug.Log("Player hit by stalactite for " + damage + " damage.");
            }
        }
    }
}
