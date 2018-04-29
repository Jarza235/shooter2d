using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private PlayerBehaviour PB;
    private GunController GC;
    public Text deathText;

    void Start()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (PB.health <= 0)
        {
            PB.theGun.isFiring = false;
			PB.theGun.isReloading = false;

            if (Input.GetKey(KeyCode.R))
            {
                PB.health = PB.maxHealth;
            }

            deathText.CrossFadeAlpha(1.0f, 0, false);
        }

        if (PB.health > 0)
        {
            deathText.CrossFadeAlpha(0.0f, 0, false);
        }
    }
}
