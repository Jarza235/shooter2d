using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarAnimation : MonoBehaviour
{
    private GunController GC;
    
    Vector3 reloadBarWidth;

    void Start ()
    {
        GC = GameObject.Find("Gun").GetComponent<GunController>();
    }
	
	
	void Update ()
    {
        if (GC.isReloading)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x += 0.025f; // Only works right if game is running 60fps
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
