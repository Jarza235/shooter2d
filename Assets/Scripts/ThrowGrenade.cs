using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float maxThrowForce;
    public float throwForce;

    public GameObject grenadePrefab;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
		if (Input.GetMouseButton(1))
        {
            if(throwForce < maxThrowForce)
            {
                throwForce += 0.1f;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            GrenadeThrow();
            Debug.Log(throwForce);
            throwForce = 5f;
        }
    }

    void GrenadeThrow()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.right * throwForce, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * -2f, ForceMode.VelocityChange);
        grenade.transform.Rotate(0f, 0f, 300f);
    }
}
