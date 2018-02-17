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
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
        DC = GameObject.Find("DamageCube").GetComponent<DamageCube>();
    }


    void Update()
    {
        if (PB.armor > 0)
        {
            armorBarWidth = transform.localScale;
            armorBarWidth.x = (1.5f / PB.maxArmor * PB.armor); // Maybe only works right if game is running 60fps
            transform.localScale = armorBarWidth;
        }

        if (PB.armor == 0)
        {
            armorBarWidth = transform.localScale;
            armorBarWidth.x = 0f;
            transform.localScale = armorBarWidth;
        }
    }
}
