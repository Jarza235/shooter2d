using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarEmpty : MonoBehaviour
{
    private GunController GC;
    public Image reloadBarEmpty;

    Vector3 reloadBarWidth;

    void Start()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
    }


    void Update()
    {
        if (GC.isReloading)
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
    }
}
