using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCube : MonoBehaviour
{
    private PlayerBehaviour PB;

    public int dealDamage; // Damage dealt to the player.

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        if (PB.damageTrigger)
        {
            if(PB.armor > 0)
            {
                PB.armor -= dealDamage;
            }

            else if(PB.armor <= 0 && PB.health >0)
            {
                PB.health -= dealDamage;
            }
        }
    }

    void OnTriggerEnter(Collider collideDamageCube)
    {
        if (collideDamageCube.gameObject.tag == "Player")
        {
            PB.damageTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collideDamageCube)
    {
        if (collideDamageCube.gameObject.tag == "Player")
        {
            PB.damageTrigger = false;
        }
    }
}
