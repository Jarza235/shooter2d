using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
	public GameObject car;

	public bool followPlayer;
	public bool followCar;
	
	// Update is called once per frame
	void Update () {
		if(followPlayer) {
			// Move the camera X & Y with the player
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		}
		else if(followCar) {
			transform.position = new Vector3(car.transform.position.x, car.transform.position.y, transform.position.z);
		}
	}
}
