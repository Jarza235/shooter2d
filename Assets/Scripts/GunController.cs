using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private ReloadBarAnimation RBA;
    private ReloadBarText RBT;
    private ReloadBarEmpty RBE;

    [HideInInspector]public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed; // Declares the speed of the bullet
    public float bulletDamage;

    public bool shotgun;
    public bool assaultRifle;
    
    // Cooldown between shots
    public float timeBetweenShots;
    public bool shootAgain;

    // Bullet spread 
    public float BulletSpreadAngle; // Random spread in angles, e.g. 5 = -5 degrees .. +5 degrees
    private float spreadZ;
    private float spreadY;

	private bool isPlayerAlive = true;

    public int maxAmmo; // How many bullets a magazine has
    public int currentAmmo; // How many bullets you have left from a magazine
    public float reloadTime; // How long time it takes to reload the gun
    [HideInInspector]public bool isReloading = false;

    public Transform firePoint;

    void Start ()
    {
        currentAmmo = maxAmmo; // Magazine starts with full ammo
        shootAgain = true;
    }

    void Awake()
    {
        RBA = GameObject.Find("ReloadBarFull").GetComponent<ReloadBarAnimation>();
        RBE = GameObject.Find("ReloadBarEmpty").GetComponent<ReloadBarEmpty>();
        RBT = GameObject.Find("ReloadingText").GetComponent<ReloadBarText>();
    }

    void OnEnable()
    {
        isReloading = false;
        RBA.animationActive = false;
        RBE.animationActive = false;
        RBT.reloadTextActive = false;
        shootAgain = true;
    }

    void Update()
    {
		// If player is alive, don't shoot
		if(!isPlayerAlive) {
			isFiring = false;
			return;
		}
        
        if (assaultRifle && isFiring && !isReloading)
        {
            bullet.bulletDamage = bulletDamage;
            AssaultRifle();
        }

        if (shotgun && isFiring && !isReloading)
        {
            bullet.bulletDamage = bulletDamage;
            PumpShotgun();
        }
    }

	public void SetIsPlayerAlive(bool alive) {
		isPlayerAlive = alive;
	}

	public void ToggleFire(bool toggle) {
		isFiring = toggle;
	}

    IEnumerator Reload() // Declares what happens when you are reloading. Player reloads gun to full ammo.
    {
        isReloading = true;
        RBA.animationLength = reloadTime;
        RBA.animationActive = true; // This and next 2: Displays reloading bar while reloading.
        RBE.animationActive = true;
        RBT.reloadTextActive = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        RBA.animationActive = false;// This and next 2: Hides reloading bar after reloaded.
        RBE.animationActive = false;
        RBT.reloadTextActive = false;
    }

    IEnumerator TimeBetweenShots()  
    {
        shootAgain = false;
        yield return new WaitForSeconds(timeBetweenShots);
        shootAgain = true;
    }

    void AssaultRifle()
    {
        if (shootAgain == true && currentAmmo > 0)
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); // Declares unique Z-angle (left-right) spread to every bullet
            newBullet.transform.Rotate(0, spreadY, spreadZ); // Spread in action
            newBullet.bulletSpeed = bulletSpeed;
            currentAmmo--; // Every bullet shot decreases one ammo from the magazine
            StartCoroutine(TimeBetweenShots()); // Player can shoot again after cooldown. timebetweenShots declares how long time you have to wait.
        }

        else if (currentAmmo <= 0) // If magazine has no ammo, reload
        {
            StartCoroutine(Reload());
            return;
        }
    }

    void PumpShotgun()
    {
        if (shootAgain == true && currentAmmo > 0) 
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet.transform.Rotate(0, spreadY, spreadZ); 
            newBullet.bulletSpeed = bulletSpeed;
            BulletController newBullet2 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet2.transform.Rotate(0, spreadY, spreadZ); 
            newBullet2.bulletSpeed = bulletSpeed;
            BulletController newBullet3 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet3.transform.Rotate(0, spreadY, spreadZ); 
            newBullet3.bulletSpeed = bulletSpeed;
            BulletController newBullet4 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet4.transform.Rotate(0, spreadY, spreadZ); 
            newBullet4.bulletSpeed = bulletSpeed;
            BulletController newBullet5 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet5.transform.Rotate(0, spreadY, spreadZ); 
            newBullet5.bulletSpeed = bulletSpeed;
            BulletController newBullet6 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet6.transform.Rotate(0, spreadY, spreadZ); 
            newBullet6.bulletSpeed = bulletSpeed;
            BulletController newBullet7 = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            spreadZ = Random.Range(-BulletSpreadAngle, BulletSpreadAngle); 
            newBullet7.transform.Rotate(0, spreadY, spreadZ); 
            newBullet7.bulletSpeed = bulletSpeed;
            currentAmmo--; 
            StartCoroutine(TimeBetweenShots());
        }

        else if (currentAmmo <= 0) // If magazine has no ammo, reload
        {
            StartCoroutine(Reload());
            return;
        }
    }
}
