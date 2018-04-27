using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : HumanBehaviour {

    public Text currentHealth; // Show player's current health by text.
    public Text currentArmor; // Show current armor by text

    [HideInInspector] public bool damageTrigger; // True if player is currently losing health.

    public GunController theGun;


	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
	}

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
		

	void Update ()
    {
        if(health > 0) // Player can't move or shoot if he's dead
        {
            /*if (Input.GetMouseButtonDown(0)) // Siirretty gun controlleriin
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }*/

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
        }

        currentHealth.text = "Life: " + health.ToString("F0"); // Shows player's current health. Hide decimals.
        currentArmor.text = "Armor: " + armor.ToString("F0");  // Shows player's current armor. Hide decimals.
    }
}
