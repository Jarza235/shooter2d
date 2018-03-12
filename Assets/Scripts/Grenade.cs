using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explodeDelay = 2f;
    private float countdown;

    public GameObject explosionEffect;
    public float blastRadius = 5f;
    public float blastForce = 700f;

    bool hasExploded = false;

	void Start ()
    {
        countdown = explodeDelay;
	}
	
	void Update ()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // Show effect 
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Destroy destructible objects // No destructible objects yet
        /*Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destructible destroy = nearbyObject.GetComponent<Destructible>();
            if (destroy != null)
            {
                destroy.Destroy();
            }
        }*/

        // Add force to nearby undestructible objects
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if ( rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);
            }
        }
        
        Destroy(gameObject); // Remove grenade
    }
}
