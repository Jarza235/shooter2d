using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapons : MonoBehaviour
{
    private PlayerBehaviour PB;

    public GameObject weapon1;
    public GameObject weapon2;

    public bool lootWeapon1;
    public bool lootWeapon2;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }
	
	/*void Update ()
    {
        
    }*/

    private void OnCollisionStay(Collision collideLootWeapon)
    {
        if(collideLootWeapon.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && lootWeapon1)
        {
            weapon1.SetActive(true);
            PB.hasWeapon1 = true; // Not implemented yet.
            PB.selectedWeapon = 0;
            PB.SelectWeapon();
            Destroy(gameObject);
        }

        if (collideLootWeapon.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && lootWeapon2)
        {
            weapon2.SetActive(true);
            PB.hasWeapon2 = true; // Not implemented yet.
            PB.selectedWeapon = 1;
            PB.SelectWeapon();
            Destroy(gameObject);
        }
    }
}
