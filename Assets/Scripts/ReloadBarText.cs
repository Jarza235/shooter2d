using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarText : MonoBehaviour
{
    private PlayerBehaviour PB;
    public Text ReloadText;
    public bool reloadTextActive;

    void Start ()
    {
        PB = GameObject.Find("Player3D").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        if (reloadTextActive && PB.health > 0)
        {
            ReloadText.CrossFadeAlpha(1.0f, 0, false);
        }

        if (!reloadTextActive)
        {
            ReloadText.CrossFadeAlpha(0.0f, 0, false);
        }

        if (PB.health <= 0)
        {
            ReloadText.CrossFadeAlpha(0.0f, 0, false);
        }
    }
}
