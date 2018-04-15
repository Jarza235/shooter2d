using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed; // Speed controlled by GunController   

    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);

        Object.Destroy(gameObject, 1.0f); // Destroys bullet after 1 sec
    }

    private void OnCollisionEnter(Collision bulletCollision)
    {
        if (bulletCollision.collider.tag.Equals("Enemy"))
        {
            Debug.Log(bulletCollision.collider.GetComponent<AIBehaviour>().health);
            bulletCollision.collider.GetComponent<AIBehaviour>().DealDamage(5);
        }
       Destroy(gameObject);
    }
}
