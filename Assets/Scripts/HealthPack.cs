using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerBehaviour PB;
    public Renderer healthPackRenderer;

    public bool instant20;
    public bool overTime40;

    private bool healOverTimeActive;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
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
            StartCoroutine(HealOverTime());
        }
    }

    // Heal over time
    public IEnumerator HealOverTime(float healSpeed = 0.02f, int healCount = 20, float healAmount = 40)
    {
        healOverTimeActive = true;
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
    }
}
