using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float maxThrowForceRight; // Forward
    public float throwForceRight;

    [HideInInspector]public float maxThrowForceForward; // Up
    [HideInInspector]public float throwForceForward;

    public GameObject grenadePrefab;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
		if (Input.GetMouseButton(1))
        {
            if(throwForceRight < maxThrowForceRight)
            {
                throwForceRight += 0.1f;
                throwForceForward -= 0.0715f;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            GrenadeThrow();
            //Debug.Log(throwForceRight);
            //Debug.Log(throwForceForward);
            throwForceRight = 5f;
            throwForceForward = 0;
        }
    }

    void GrenadeThrow()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.right * throwForceRight + transform.forward * throwForceForward, ForceMode.VelocityChange);
        grenade.transform.Rotate(0f, 0f, 300f);
    }
}
