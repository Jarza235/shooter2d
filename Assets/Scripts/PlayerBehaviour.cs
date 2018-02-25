using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : HumanBehaviour {

    public float health;  // Player's current health.
    public int maxHealth; // Player's max health.
    public Text currentHealth; // Show player's current health by text.

    public int armor; // Player's current armor.
    public int maxArmor; // Player's max armor.
    public Text currentArmor; // Show current armor by text

    [HideInInspector] public bool damageTrigger; // True if player is currently losing health.

    public GunController theGun;


	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		health = maxHealth; // Player starts with full health.
		armor = 0; // Player starts with 0 armor.
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
            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
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

			if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) {
				// Do nothing
			}
			else {
				CalculateDirection();
				Rotate();
				Move();
			}	
        }

        currentHealth.text = "Life: " + health; // Shows player's current health.
        currentArmor.text = "Armor: " + armor;  // Shows player's current armor.
    }
}
