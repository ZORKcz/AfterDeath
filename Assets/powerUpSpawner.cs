using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
	//public PlayOneShotBehaviour script;

	public GameObject redBottle;
	public GameObject armorBoots;
	public GameObject leatherBoots;
	public GameObject chestPlate;
	public GameObject arrow;
	public GameObject axe;
	public GameObject blueBottle;
	public bool enemyHasDied;
	public Transform enemy;

	public Damageable script;

	public bool hasBeenActivatedOnce;
	int index = 0;
	void Start()
	{
		index = 0;
		hasBeenActivatedOnce = false;
	}
	void Update()
	{
		if (script.Health <= 0)
		{
			enemyHasDied = true;
		}
		if (!hasBeenActivatedOnce && enemyHasDied)
		{
			Debug.Log("************************************------------------------------------------");
			DropPowerUpOnDeath();
			hasBeenActivatedOnce = true;
		}
	}


	public void DropPowerUpOnDeath()
	{
		GameObject powerUp;
		int randomIndex = Random.Range(0, 8);
		int randomItemNumber = Random.Range(0, 7);
		Debug.Log(randomItemNumber + " random powerup");
		Debug.Log(randomIndex + "nahodne cislo");
		if (randomIndex == 1)
		{
			switch (randomItemNumber)
			{
				case 1:
					powerUp = Instantiate(redBottle, enemy.position, Quaternion.identity);
					break;
				case 2:
					powerUp = Instantiate(armorBoots, enemy.position, Quaternion.identity);
					break;
				case 3:
					powerUp = Instantiate(leatherBoots, enemy.position, Quaternion.identity);
					break;
				case 4:
					powerUp = Instantiate(chestPlate, enemy.position, Quaternion.identity);
					break;
				case 5:
					powerUp = Instantiate(arrow, enemy.position, Quaternion.identity);
					break;
				case 6:
					powerUp = Instantiate(axe, enemy.position, Quaternion.identity);
					break;
				default:
					powerUp = Instantiate(blueBottle, enemy.position, Quaternion.identity);
					break;
			}
		}
	}
}
