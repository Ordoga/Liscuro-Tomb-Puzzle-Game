using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEnabler : MonoBehaviour
{
    private bool canSwitch;
    GameManager gm;

    void Start()
    {
        canSwitch = false;
        gm = FindObjectOfType<GameManager>();
        gm.swapEnabled = false;
    }
    void Update()
    {
        if (!canSwitch)
        {
            gm.swapEnabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)// if detected dark rect collision, enable transition to light
    {
        if (other.gameObject.tag == "DarkRect" || other.gameObject.tag == "LightRect")
        {
            Debug.Log("dark collisioned");
            gm.swapEnabled = true;
            canSwitch = true;

        }
    }
}
