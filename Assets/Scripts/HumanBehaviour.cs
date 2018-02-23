using UnityEngine;
using System.Collections;

public class HumanBehaviour : MonoBehaviour
{
	public GameObject HandLeft;
	public GameObject HandRight;
	public GameObject LegLeft;
	public GameObject LegRight;

	protected float armRotationSpeed = 0f;
	protected float armRotationDirection = 1f;
	protected float armTravelLenghtCounter = 0.0f;

	protected Rigidbody rb;
	protected float movementForce = 10f;
	protected float characterRotationSpeed = 3f;
	protected float maxSpeed = 5f;


	// Use this for initialization
	virtual protected void Start () {
		rb = GetComponent<Rigidbody>();
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

