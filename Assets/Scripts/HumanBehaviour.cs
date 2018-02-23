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
	protected float movementForce = 10f;
	protected float characterRotationSpeed = 3f;
	protected float maxSpeed = 5f;
	protected Vector2 input;
	protected float angle;
	protected Quaternion targetRotation;
	protected float turnSpeed = 10f;


	virtual protected void Start () {
		rb = GetComponent<Rigidbody>();
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
		if(rb.velocity.magnitude < maxSpeed) {
			rb.AddForce(transform.right * movementForce);
		}
	}

	// Update is called once per frame
	virtual protected void FixedUpdate () {

		// Arm rotation speed depends on the player speed. Cap the arm speed to fixed value.
		armRotationSpeed = Mathf.Min(rb.velocity.magnitude, 2.5f) * 1.7f;
		AnimateWalk();
		armTravelLenghtCounter += armRotationSpeed;
	}

	virtual protected void AnimateWalk() {
		float maxTravelLenght = 30f;
		if(armTravelLenghtCounter < maxTravelLenght) {
			HandLeft.transform.Rotate(Vector3.up  * armRotationSpeed * armRotationDirection);
			HandRight.transform.Rotate(Vector3.up * armRotationSpeed * -armRotationDirection);

			LegLeft.transform.Rotate(Vector3.up  * armRotationSpeed * -armRotationDirection);
			LegRight.transform.Rotate(Vector3.up * armRotationSpeed * armRotationDirection);
		}
		else {
			armRotationDirection *= -1f;
			armTravelLenghtCounter = -armTravelLenghtCounter;
		}
	}
}

