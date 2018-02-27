using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerBehaviour PB;
    private HealthBarAnimation HBA;
    public Renderer healthPackRenderer;

    public bool instant20;
    public bool overTime40;

    public bool healOverTimeActive;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
        HBA = GameObject.Find("HealthBarRege").GetComponent<HealthBarAnimation>();
        healthPackRenderer = GetComponent<Renderer>();
    }
	
	/*void Update ()
    {
        
    }*/

    private void OnCollisionEnter(Collision collideHealthPack)
    {
        if(instant20 && collideHealthPack.gameObject.tag == "Player" && PB.health < 100)
        {
            PB.health += 20;
            if (PB.health > 100)
            {
                PB.health = 100;
            }
            Destroy(gameObject);
        }

        if (!healOverTimeActive && overTime40 && collideHealthPack.gameObject.tag == "Player" && PB.health < 100)
        {
            healthPackRenderer.enabled = false;
            HBA.healthBeforeRege = PB.health;
            HBA.amountRegenerated = 40;
            StartCoroutine(HealOverTime());
        }
    }

    // Heal over time
    public IEnumerator HealOverTime(float healSpeed = 0.02f, int healCount = 50, float healAmount = 40)
    {
        healOverTimeActive = true;
        HBA.healthBarRegeActive = true;
        int currentHealCount = 0;
        while (currentHealCount < healCount && PB.health < 100)
        {
            PB.health += (healAmount / healCount);
            yield return new WaitForSeconds(healSpeed);
            currentHealCount++;
            if (PB.health > 100)
            {
                PB.health = 100;
            }
        }
        healOverTimeActive = false;
        Destroy(gameObject);
        HBA.healthBarRegeActive = false;
    }
}
