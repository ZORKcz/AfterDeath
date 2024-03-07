using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
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
        rb.velocity = new Vector2(-moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>(); 

        if (damageable != null) 
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y); // Vypo��t�n� sm�ru a s�ly odrazu

            bool gotHit = damageable.Hit(damage, deliveredKnockBack);

            if (gotHit) // Pokud bylo po�kozen� �sp�n�
            {
                Debug.Log(collision.name + " hit for " + damage); 
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        CheckDespawnDistance(); // Kontrola, zda m� projektil b�t zni�en kv�li velk� vzd�lenosti od po��te�n� pozice
    }

    private void CheckDespawnDistance()
    {
        float distance = Vector2.Distance(transform.position, initialPosition);

        if (distance >= 100f) // Pokud je projektil p��li� daleko
        {
            Destroy(gameObject); // Zni�en� projektilu
        }
    }
}
