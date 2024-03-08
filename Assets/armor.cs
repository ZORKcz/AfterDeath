using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : MonoBehaviour
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
        if (list.armorIsActive)
        {
            if (startCourutineOnce)
            {
                StartCoroutine(armorCO());
            }
        }
    }

    private IEnumerator armorCO()
    {
        Debug.Log("Courutine bezi");
        startCourutineOnce = false;
        list.OnArmorPickUp();
        yield return new WaitForSeconds(20);
        list.OnArmorPickUpReturn();
        list.armorIsActive = false;
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
