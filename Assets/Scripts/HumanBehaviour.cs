using UnityEngine;
using System.Collections;

public class HumanBehaviour : MonoBehaviour
{
	public GameObject HandLeft;
	public GameObject HandRight;
	public GameObject LegLeft;
	public GameObject LegRight;

	// Walk animation
	protected float armRotationSpeed = 0f;
	protected float armRotationDirection = 1f;
	protected float armTravelLenghtCounter = 0.0f;

	protected Rigidbody rb;

	// Movement
	protected float movementForce = 20f;
	protected float characterRotationSpeed = 3f; // Useless?
	protected float maxSpeed = 5f;
	protected Vector2 input;
	protected float angle;
	protected Quaternion targetRotation;
	protected float turnSpeed = 10f;

    public float health;  // Player's current health.
    public float maxHealth; // Player's max health.

    public float armor; // Player's current armor.
    public float maxArmor; // Player's max armor.

	public GunController theGun;
	public int selectedWeapon = 0;


    virtual protected void Start ()
    {
		rb = GetComponent<Rigidbody>();
        health = maxHealth; // Player starts with full health.
        armor = 0; // Player starts with 0 armor.
    }

	virtual protected void CalculateDirection()
	{
		angle = Mathf.Atan2(input.x, input.y);
		angle *= Mathf.Rad2Deg;
	}

	virtual protected void Rotate()
	{
		targetRotation = Quaternion.Euler(0f, angle - 90f, 0f);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
	}

	virtual protected void Move()
	{
        armRotationSpeed = 4.25f;
        transform.position += transform.right * maxSpeed * Time.deltaTime; //<- Test: Player movement is better, but body is not animated.
    }

    virtual protected void StandStill()
    {
        armRotationSpeed = 0;
    }

    // Update is called once per frame
    virtual protected void FixedUpdate ()
    {
		AnimateWalk();
		armTravelLenghtCounter += armRotationSpeed;     

		if(health <= 0) {
			theGun.SetIsPlayerAlive(false);
		}
	}

    virtual protected void AnimateWalk()
    {
		float maxTravelLenght = 30f;
		if(armTravelLenghtCounter < maxTravelLenght)
        {
			HandLeft.transform.Rotate(Vector3.up  * armRotationSpeed * armRotationDirection);
			HandRight.transform.Rotate(Vector3.up * armRotationSpeed * -armRotationDirection);

			LegLeft.transform.Rotate(Vector3.up  * armRotationSpeed * -armRotationDirection);
			LegRight.transform.Rotate(Vector3.up * armRotationSpeed * armRotationDirection);
		}
		else
        {
			armRotationDirection *= -1f;
			armTravelLenghtCounter = -armTravelLenghtCounter;
		}
	}

	virtual protected void SwitchWeapon() {
		// Implementation is in PlayerBehaviour and in AIBehaviour
	}

	public void SelectWeapon() // Muutin tämän publiciksi, jotta LootWeapons futaa. 
    {
		int i = 0;
		foreach (Transform weapon in transform.Find("Weapons"))
		{
			if (i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
				theGun = weapon.GetComponent<GunController>();
			}

			else
			{
				weapon.gameObject.SetActive(false);
			}

			i++;
		}
	}

	public void DealDamage(float damageAmount)
	{

		if (armor > 0)
		{
			if (damageAmount > armor)
			{
				health -= (damageAmount - armor);
				armor = 0;
			}

			else
			{
				armor -= damageAmount;
			}
		}

		else if (health > 0)
		{
			health -= damageAmount;
		}

		if (health <= 0)
		{
			Die();
		}
	}

	virtual protected void Die()
	{
		Debug.Log("Dead");
	}
}

