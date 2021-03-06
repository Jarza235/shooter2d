﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : HumanBehaviour
{ 
    public Text currentHealth; // Show player's current health by text.
    public Text currentArmor; // Show current armor by text
	public Text deathText;

    public int carryWeapon1;
    public int carryWeapon2;
    public int carryWeaponAmount = 0;

    [HideInInspector] public bool damageTrigger; // True if player is currently losing health.


	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		deathText.CrossFadeAlpha(0.0f, 0, false);
	}

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

	protected override void SwitchWeapon()
    {
		int previousSelectedWeapon = selectedWeapon;

		/*if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Switch weapon with mouse scroll wheel.
		{
			if (selectedWeapon >= transform.Find("Weapons").childCount - 1)
			{
				selectedWeapon = 0;
			}
			else
			{
				selectedWeapon++;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectedWeapon <= 0)
			{
				selectedWeapon = transform.Find("Weapons").childCount - 1;
			}
			else
			{
				selectedWeapon--;
			}
		}*/

		if (Input.GetKeyDown(KeyCode.Alpha1) /*&& hasWeapon1*/) // Switch weapon with numbers.
		{
            //selectedWeapon = 0;
            selectedWeapon = carryWeapon1;
        }
		if (Input.GetKeyDown(KeyCode.Alpha2) /*&&*/ /*transform.Find("Weapons").childCount >= 2 &&*/ /*hasWeapon2*/)
		{
            //selectedWeapon = 1;
            selectedWeapon = carryWeapon2;
        }

		if (previousSelectedWeapon != selectedWeapon)
		{
			SelectWeapon();
		}
	}

	protected override void Die()
    {
		theGun.isFiring = false;
		theGun.isReloading = false;

		deathText.CrossFadeAlpha(1.0f, 0, false);
	}

	private void Respawn()
    {
		if (Input.GetKey(KeyCode.R))
		{
			health = maxHealth;
			theGun.SetIsPlayerAlive(true);
			deathText.CrossFadeAlpha(0.0f, 0, false);
		}
	}

	void Update ()
    {
        if(health > 0) // Player can't move or shoot if he's dead
        {

			if (Input.GetMouseButtonDown(0))
			{
				theGun.ToggleFire(true);
			}
			if (Input.GetMouseButtonUp(0))
			{
				theGun.ToggleFire(false);
			}

            if (Input.GetKey(KeyCode.K)) // Inflict damage by pressing K
            {
                if (armor > 0)
                {
                    armor--;
                }
                else if (health > 0)
                {
                    health--;
                }
            }

            GetInput();

			if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1)
            {
                StandStill();
			}
			else
            {
				CalculateDirection();
				Rotate();
				Move();
			}

			SwitchWeapon();
        }
			
        currentHealth.text = "Life: " + health.ToString("F0"); // Shows player's current health. Hide decimals.
        currentArmor.text = "Armor: " + armor.ToString("F0");  // Shows player's current armor. Hide decimals.

		Respawn();
    }
}
