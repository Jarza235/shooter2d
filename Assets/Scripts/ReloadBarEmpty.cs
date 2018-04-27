using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarEmpty : MonoBehaviour
{
    private PlayerBehaviour PB;
    public bool animationActive;

    Vector3 reloadBarWidth;

    void Start()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (animationActive && PB.health > 0)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x = 1.5f;
            transform.localScale = reloadBarWidth;
        }

        if (!animationActive)
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
