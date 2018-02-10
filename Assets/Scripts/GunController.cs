using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed; // Declares the speed of the bullet

    // Cooldown between shots
    public float timeBetweenShots;
    private float shotCounter;

    // Bullet spread 
    public float BulletSpread; // Random spread in angles, e.g. 5 = -5 degrees .. +5 degrees
    private float spreadZ;

    public Transform firePoint; 

    void Start ()
    {
		
    }
	
	void Update ()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0) // Player can shoot again after shotCounter <= 0. timebetweenShots declares how long time you have to wait.
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                spreadZ = Random.Range(-BulletSpread, BulletSpread); // Declares unique spread to every bullet
                newBullet.transform.Rotate(0, 0, spreadZ); // Spread in action
                newBullet.bulletSpeed = bulletSpeed; 
            }
        }
        else
        {
            shotCounter = 0;
        }
        Debug.Log(shotCounter);
	}
}
