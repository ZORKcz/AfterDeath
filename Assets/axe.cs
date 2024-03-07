using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public listOfPowerUpsMethods list;
    public console consoleScript;

    public bool startCourutineOnce;

    void Start()
    {
        startCourutineOnce = true;    
    }

    void Update()
    {
        if (list.damageBonusIsActive)
        {
            if (startCourutineOnce)
            {
                StartCoroutine(axePowerUp());
            }
        }
    }

    private IEnumerator axePowerUp()
    {
        Debug.Log("Courutine bezi");
        startCourutineOnce = false;
        list.OnAxePickUp();
        yield return new WaitForSeconds(5);
        if (!consoleScript.strengthHasBeenAdded)
        {
            list.OnAxePickUpReturn();
        }
        list.damageBonusIsActive = false;
        startCourutineOnce = true;
    }

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
