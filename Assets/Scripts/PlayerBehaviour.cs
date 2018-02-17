﻿using System.Collections;
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

    //public bool noRotationAnimation;
    //public bool yesRotationAnimation;

    [HideInInspector] public bool damageTrigger; // True if player is currently losing health.

    public GunController theGun;


    /// <summary>
    /// Rotation animation
    /// </summary>

    public float velocity = 5;
    public float turnSpeed = 10;

    Vector2 input;
    float angle;

    Quaternion targetRotation;

    /// <summary>
    /// Input is based on Horizontal and Vertical keys
    /// </summary>
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Calculates player's direction
    /// </summary>
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
    }

    /// <summary>
    /// Player's smooth rotation
    /// </summary>
    void Rotate()
    {
        targetRotation = Quaternion.Euler(90, angle, 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Player only moves along its right axis
    /// </summary>
    void Move()
    {
        transform.position += transform.right * velocity * Time.deltaTime;
    }

    
    

    // Use this for initialization
    void Start ()
    {
        health = maxHealth; // Player starts with full health.
        armor = maxArmor; // Player starts with full armor.
	}
	
	// Update is called once per frame
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

                if (armor <= 0 && health > 0)
                {
                    health--;
                }
            }

            GetInput();

            if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;
            {
                CalculateDirection();
                Rotate();
                Move();
            }

            /*if (noRotationAnimation)
            {
                // Move player with WASD
                if (Input.GetKey(KeyCode.W))
                {
                    //transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
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
            }*/

            /*if (yesRotationAnimation)
            {
                GetInput();

                if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;
                {
                    CalculateDirection();
                    Rotate();
                    Move();
                }
            }*/
        }

        currentHealth.text = ("Life: " + health); // Shows player's current health.
        currentArmor.text = ("Armor: " + armor); // Shows player's current armor.
    }
}
