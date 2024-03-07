using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listOfPowerUpsMethods : MonoBehaviour
{
	public Attack attackDamage;
	public PlayerController playerSpeed;
	public Damageable healthBar;

	public bool armorIsActive;
	public bool damageBonusIsActive;
	public bool speedBonusIsActive;

	void Start()
	{
		armorIsActive = false;
		damageBonusIsActive = false;
		speedBonusIsActive = false;
	}

	public void OnAxePickUp()
	{
		attackDamage.attackDamage *= 2;
	}

	public void OnAxePickUpReturn()
	{
		attackDamage.attackDamage /= 2;
	}

	public void OnArrowPickUp()
	{
		playerSpeed.currentArrows += 6 - playerSpeed.currentArrows;
	}

	public void OnArmorPickUp()
	{
		healthBar.MaxHealth = 150;
		healthBar.Heal(50);
	}

	public void OnArmorPickUpReturn()
	{
		healthBar.MaxHealth = 100;
	}

	public void OnSpeedPickUp()
	{
		playerSpeed.walkSpeed *= 2;
		playerSpeed.runSpeed *= 2;
		playerSpeed.airWalkSpeed *= 2;
	}

	public void OnSpeedPickUpReturn()
	{
		playerSpeed.walkSpeed /= 2;
		playerSpeed.runSpeed /= 2;
		playerSpeed.airWalkSpeed /= 2;
	}
}
