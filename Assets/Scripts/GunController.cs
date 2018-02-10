﻿using System.Collections;
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

    public int maxAmmo; // How many bullets a magazine has
    private int currentAmmo; // How many bullets you have left from a magazine
    public float reloadTime; // How long time it takes to reload the gun
    private bool isReloading = false;

    public Transform firePoint; 

    void Start ()
    {
        currentAmmo = maxAmmo; // Magazine starts with a full ammo
    }
	
	void Update ()
    {
        if (isReloading) // Checks if gun is reloading
        {
            return;
        }
            

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
                currentAmmo--; // Every bullet shot decreases one ammo from the magazine
            }
        }
        else
        {
            shotCounter = 0;
        }
        
        if (currentAmmo <= 0) // If magazine has no ammo, reload
        {
            StartCoroutine(Reload());
            return;
        }
	}

    IEnumerator Reload() // Declares what happens when you are reloading. Player reloads gun to full ammo.
    {
        isReloading = true;
        Debug.Log("Reloading..." + reloadTime + "sec");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload done!");
    }
}