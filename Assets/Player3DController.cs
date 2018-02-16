using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour {

	public GameObject HandLeft;
	public GameObject HandRight;
	public GameObject LegLeft;
	public GameObject LegRight;

	private float armRotationSpeed = 2.5f;
	private float timer = 0.0f;

	private Rigidbody rb;
	private float force = 10f;
	private float characterRotationSpeed = 3f;
	private float maxSpeed = 5f;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		if(Input.GetKey(KeyCode.W)) {
			if(rb.velocity.magnitude < maxSpeed)
				rb.AddForce(-transform.right * force);
		}
		if(Input.GetKey(KeyCode.S)) {
			if(rb.velocity.magnitude < maxSpeed)
				rb.AddForce(transform.right * force);
		}
		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(-Vector3.up * characterRotationSpeed);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.up * characterRotationSpeed);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		AnimateWalk();
		timer += Time.fixedDeltaTime;

		Debug.Log(rb.velocity.magnitude + " speed");
	}

	private void AnimateWalk() {
		if(timer < 0.2f) {
			HandLeft.transform.Rotate(Vector3.up * armRotationSpeed);
			HandRight.transform.Rotate(Vector3.up * -armRotationSpeed);

			LegLeft.transform.Rotate(Vector3.up * -armRotationSpeed);
			LegRight.transform.Rotate(Vector3.up * armRotationSpeed);
		}
		else {
			armRotationSpeed *= -1f;
			timer = -0.2f;
		}
	}


}
