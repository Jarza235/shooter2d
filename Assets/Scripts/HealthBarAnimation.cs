using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAnimation : MonoBehaviour
{
    private PlayerBehaviour PB;
    private DamageCube DC;
    //public Image reloadBar;

    Vector3 healthBarWidth;

    void Start()
    {
        PB = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        DC = GameObject.Find("DamageCube").GetComponent<DamageCube>();
    }


    void Update()
    {
        if (PB.damageTrigger) //testi
        {
            healthBarWidth = transform.localScale;
            healthBarWidth.x -= (0.015f*DC.dealDamage); // Only works right if game is running 60fps
            transform.localScale = healthBarWidth;
        }

        /*if (!damageTrigger)
        {
            healthBarWidth = transform.localScale;
            healthBarWidth.x = 0f;
            transform.localScale = healthBarWidth;
        }*/
    }
}
