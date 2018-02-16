using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarText : MonoBehaviour
{
    private GunController GC;
    private PlayerBehaviour PB;
    public Text ReloadText;

    void Start ()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
        PB = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        if (GC.isReloading && PB.health > 0)
        {
            ReloadText.CrossFadeAlpha(1.0f, 0, false);
        }

        if (!GC.isReloading)
        {
            ReloadText.CrossFadeAlpha(0.0f, 0, false);
        }

        if (PB.health <= 0)
        {
            ReloadText.CrossFadeAlpha(0.0f, 0, false);
        }
    }
}
