using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 6;
    public Vector2 moveSpeed = new Vector2(3f, 0);
    public Vector2 knockback = new Vector2(0, 0);

    private Rigidbody2D rb;
    private Vector2 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            // Udeøit cíl
            bool goHit = damageable.Hit(damage, deliveredKnockBack);

            if (goHit)
            {
                Debug.Log(collision.name + " hit for " + damage);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        CheckDespawnDistance();
    }

    private void CheckDespawnDistance()
    {
        float distance = Vector2.Distance(transform.position, initialPosition);

        if (distance >= 100f)  //Zmenit do jaké vzdálenosti má šíp doletìt
        {
            Destroy(gameObject);
        }
    }
}