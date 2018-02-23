using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerBehaviour PB;
    public bool instant20;
    public bool overTime40;

    private bool healOverTime;

    public Renderer healthPackRenderer;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
        healthPackRenderer = GetComponent<Renderer>();
    }
	
	
	void Update ()
    {
        if (healOverTime)
        {
            if(PB.health < 100)
            {
                PB.health += 10f * Time.deltaTime;
                
            }
            if (PB.health > 100)
            {
                PB.health = 100;
            }
        }
    }

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

        if (overTime40 && collideHealthPack.gameObject.tag == "Player" && PB.health < 100)
        {
            StartCoroutine(HealOverTimeTimer());
            healthPackRenderer.enabled = false;
        }
    }

    IEnumerator HealOverTimeTimer() // .
    {
        healOverTime = true;
        yield return new WaitForSeconds(5);
        healOverTime = false;
        Destroy(gameObject);
    }
}
