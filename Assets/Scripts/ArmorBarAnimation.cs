using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBarAnimation : MonoBehaviour
{
    private PlayerBehaviour PB;
    private DamageCube DC;

    Vector3 armorBarWidth;

    void Start()
    {
        PB = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        DC = GameObject.Find("DamageCube").GetComponent<DamageCube>();
    }


    void Update()
    {
        if (PB.damageTrigger && PB.armor > 0)
        {
            armorBarWidth = transform.localScale;
            armorBarWidth.x -= (0.015f * DC.dealDamage); // Only works right if game is running 60fps
            transform.localScale = armorBarWidth;
        }
    }
}
