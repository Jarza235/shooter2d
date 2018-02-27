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

        if (healthBarRegeActive && healthBarRege && PB.health > 0)
        {
            healthBarWidth = transform.localScale;
            healthBarWidth.x = (1.5f / PB.maxHealth * (healthBeforeRege + 40));
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
