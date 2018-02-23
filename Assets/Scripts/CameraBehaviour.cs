using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
	public GameObject car;

	public bool followPlayer;
	public bool followCar;

	public bool useThirdPersonCamera;
	private float offsetZ;

	private Rigidbody carRb;

	void Start() {
		carRb = car.GetComponent<Rigidbody>();

		if(useThirdPersonCamera) {
			transform.eulerAngles = new Vector3(40f, 0f, 0f);
			offsetZ = 10f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(followPlayer) {
			// Move the camera X & Y with the player
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 20f, player.transform.position.z);
		}
		else if(followCar) {
			transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 20f + Mathf.Min(carRb.velocity.magnitude, 15f), car.transform.position.z - offsetZ);
		}
	}
}
