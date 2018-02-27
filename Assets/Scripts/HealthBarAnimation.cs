using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAnimation : MonoBehaviour
{
    private PlayerBehaviour PB;
    private DamageCube DC;

    Vector3 healthBarWidth;

    public bool healthBarFull;
    public bool healthBarRege;
    public bool healthBarRegeActive;

    public float healthBeforeRege;
    public float amountRegenerated;

    void Start()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
        DC = GameObject.Find("DamageCube").GetComponent<DamageCube>();
    }


    void Update()
    {
        if (healthBarFull && PB.armor <= 0 && PB.health >= 0)
        {
            healthBarWidth = transform.localScale;
            healthBarWidth.x = (1.5f / PB.maxHealth * PB.health);
            transform.localScale = healthBarWidth;
        }

        if (healthBarRegeActive && healthBarRege && PB.health > 0) // Health regeneration visual effect
        {
            healthBarWidth = transform.localScale;
            if(healthBeforeRege + amountRegenerated <= PB.maxHealth)
            {
                healthBarWidth.x = (1.5f / PB.maxHealth * (healthBeforeRege + amountRegenerated));
            }
            if(healthBeforeRege + amountRegenerated > PB.maxHealth)
            {
                healthBarWidth.x = 1.5f;
            }
            
            transform.localScale = healthBarWidth;
        }

        if (!healthBarRegeActive && healthBarRege && PB.health > 0)
        {
            healthBarWidth = transform.localScale;
            healthBarWidth.x = 0f;
            transform.localScale = healthBarWidth;
        }
    }
}
