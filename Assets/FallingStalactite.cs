using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStalactite : MonoBehaviour
{
    public int damage = 6;
    public float distance;
    bool isFalling = false;

    public Vector2 knockback = new Vector2(0, 0);

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;

        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                rb.gravityScale = 5;
                isFalling = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();

            if (damageable != null)
            {
                Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

                damageable.Hit(damage, deliveredKnockBack);
                Debug.Log("Player hit by stalactite for " + damage + " damage.");
            }
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }
}
