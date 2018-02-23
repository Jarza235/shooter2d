using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPack : MonoBehaviour
{
    private PlayerBehaviour PB;
    public bool armor35;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }
	
	
	void Update ()
    {
        
    }

    private void OnCollisionEnter(Collision collideArmorPack)
    {
        if(armor35 && collideArmorPack.gameObject.tag == "Player" && PB.armor < 100)
        {
            PB.armor += 35;
            if (PB.armor > 100)
            {
                PB.armor = 100;
            }
            Destroy(gameObject);
        }
    }
}
