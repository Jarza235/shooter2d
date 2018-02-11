using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarText : MonoBehaviour
{
    private GunController GC;
    public Text ReloadText;

    void Start ()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
    }
	
	void Update ()
    {
        if (GC.isReloading)
        {
            ReloadText.CrossFadeAlpha(1.0f, 0, false);
        }

        if (!GC.isReloading)
        {
            ReloadText.CrossFadeAlpha(0.0f, 0, false);
        }
    }
}
