using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.2f;

    public int health;  // Player's current health.
    public int maxHealth; // Player's max health.
    public Text currentHealth; // Show player's current health by text.

    public int armor; // Player's current armor.
    public int maxArmor; // Player's max armor.
    public Text currentArmor; // Show current armor by text

    [HideInInspector] public bool damageTrigger; // True if player is currently losing health.


    public GunController theGun;

    // Use this for initialization
    void Start ()
    {
        health = maxHealth; // Player starts with full health.
        armor = maxArmor; // Player starts with full armor.
	}
	
	// Update is called once per frame
	void Update () {
        // Move player with WASD
		if(Input.GetKey(KeyCode.W))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+speed);
            transform.rotation = Quaternion.Euler(90.0f, 270.0f, 0.0f); // x,y,z
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            transform.rotation = Quaternion.Euler(90.0f, 90.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(90.0f, 45.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(90.0f, 315.0f, 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(90.0f, 180.0f, 0.0f);

            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(90.0f, 135.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(90.0f, 225.0f, 0.0f);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }

        currentHealth.text = ("Life: " + health); // Shows player's current health.
        currentArmor.text = ("Armor: " + armor); // Shows player's current armor.
    }
}
