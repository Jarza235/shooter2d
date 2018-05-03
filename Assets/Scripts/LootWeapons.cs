using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapons : MonoBehaviour
{
    private PlayerBehaviour PB;

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    public bool lootWeapon1;
    public bool lootWeapon2;
    public bool lootWeapon3;

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
            LootWeapon1();
        }

        if (collideLootWeapon.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && lootWeapon2)
        {
            LootWeapon2();
        }

        if (collideLootWeapon.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && lootWeapon3)
        {
            LootWeapon3();
        }
    }

    void LootWeapon1()
    {
        weapon1.SetActive(true);
        
        if (PB.carryWeaponAmount == 0)
        {
            PB.carryWeapon1 = 0;
        }
        if (PB.carryWeaponAmount == 1)
        {
            PB.carryWeapon2 = 0;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon1)
        {
            PB.carryWeapon1 = 0;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon2)
        {
            PB.carryWeapon2 = 0;
        }

        PB.selectedWeapon = 0;
        PB.SelectWeapon();
        PB.carryWeaponAmount++;
        Destroy(gameObject);
    }

    void LootWeapon2()
    {
        weapon2.SetActive(true);

        if (PB.carryWeaponAmount == 0)
        {
            PB.carryWeapon1 = 1;
        }
        if (PB.carryWeaponAmount == 1)
        {
            PB.carryWeapon2 = 1;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon1)
        {
            PB.carryWeapon1 = 1;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon2)
        {
            PB.carryWeapon2 = 1;
        }

        PB.selectedWeapon = 1;
        PB.SelectWeapon();
        PB.carryWeaponAmount++;
        Destroy(gameObject);
    }

    void LootWeapon3()
    {
        weapon3.SetActive(true);

        if (PB.carryWeaponAmount == 0)
        {
            PB.carryWeapon1 = 2;
        }
        if (PB.carryWeaponAmount == 1)
        {
            PB.carryWeapon2 = 2;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon1)
        {
            PB.carryWeapon1 = 2;
        }
        if (PB.carryWeaponAmount >= 2 && PB.selectedWeapon == PB.carryWeapon2)
        {
            PB.carryWeapon2 = 2;
        }

        PB.selectedWeapon = 2;
        PB.SelectWeapon();
        PB.carryWeaponAmount++;
        Destroy(gameObject);
    }
}
