using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCube : MonoBehaviour
{
    private PlayerBehaviour PB;

    public int dealDamage;
    //[HideInInspector]public bool damageTrigger;

    void Start ()
    {
        PB = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        if (PB.damageTrigger)
        {
            PB.health -= dealDamage;
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
