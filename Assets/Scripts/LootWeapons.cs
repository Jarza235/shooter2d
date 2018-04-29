using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapons : MonoBehaviour
{
    private PlayerBehaviour PB;
    private HealthBarAnimation HBA;
    public GameObject weapon;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
        HBA = GameObject.Find("HealthBarRege").GetComponent<HealthBarAnimation>();
    }
	
	/*void Update ()
    {
        
    }*/

    private void OnCollisionStay(Collision collideLootWeapon)
    {
        if(collideLootWeapon.gameObject.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            weapon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
