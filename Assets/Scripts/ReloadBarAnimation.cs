using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarAnimation : MonoBehaviour
{
    private GunController GC;
    private PlayerBehaviour PB;

    Vector3 reloadBarWidth;

    void Start ()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
        PB = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }
	
	
	void Update ()
    {
        if (GC.isReloading && reloadBarWidth.x < 1.5f && PB.health > 0)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x += (0.025f / GC.reloadTime); // Maybe only works right if game is running 60fps
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
