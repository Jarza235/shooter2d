using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

	public GameObject roof;

	/*void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision");
		if(collision.gameObject.tag.Equals("Player")) {
			roof.SetActive(false);
			Debug.Log("Collision with player and door");
		}
	}*/
		
	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			if(roof.activeInHierarchy) {
				roof.SetActive(false);
			}
			else {
				roof.SetActive(true);
			}
		}
	}

}
