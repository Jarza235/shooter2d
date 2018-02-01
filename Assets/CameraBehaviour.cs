using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move the camera X & Y with the player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
}
