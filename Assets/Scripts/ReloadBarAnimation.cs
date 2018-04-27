using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarAnimation : MonoBehaviour
{
    private PlayerBehaviour PB;

    Vector3 reloadBarWidth;

    public bool animationActive;
    public float animationLength;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        if (animationActive && reloadBarWidth.x < 1.5f && PB.health > 0)
        {
            reloadBarWidth = transform.localScale;
            reloadBarWidth.x += (0.025f / animationLength); // Maybe only works right if game is running 60fps
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
