using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

	public GameObject roof;
		
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
