using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarEmpty : MonoBehaviour
{
    private GunController GC;
    private PlayerBehaviour PB;
    //public Image reloadBarEmpty;

    Vector3 reloadBarWidth;

    void Start()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }


    void Update()
    {
        if (GC.isReloading && PB.health > 0)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x = 1.5f;
            transform.localScale = reloadBarWidth;
        }

        if (!GC.isReloading)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x = 0f;
            transform.localScale = reloadBarWidth;
        }

        if (PB.health <= 0)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x = 0f;
            transform.localScale = reloadBarWidth;
        }
    }
}
