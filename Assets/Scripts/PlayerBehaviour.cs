using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.2f;

    public GunController theGun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move player with WASD
		if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);

            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 225.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
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
    }
}
