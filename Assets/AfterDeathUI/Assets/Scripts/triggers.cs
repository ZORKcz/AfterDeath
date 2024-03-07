using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggers : MonoBehaviour
{
    public listOfPowerUpsMethods list;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "leatherBoots")
        {
            list.speedBonusIsActive = true;
        }

        if (collision.collider.tag == "armor")
        {
            list.armorIsActive = true;
        }

        if (collision.collider.tag == "axe")
        {

            list.damageBonusIsActive = true;
        }

        if (collision.collider.tag == "arrow")
        {
            list.OnArrowPickUp();
        }
    }
}
