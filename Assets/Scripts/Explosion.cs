using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    

    void Start ()
    {
		
	}
	
	void Update ()
    {
        Object.Destroy(gameObject, 1.2f);
    }
}
