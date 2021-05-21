﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEnabler : MonoBehaviour
{
    private bool canSwitch;

    void Start()
    {
        canSwitch = false;
        FindObjectOfType<GameManager>().swapEnabled = false;
    }
    void Update()
    {
        if (!canSwitch)
        {
            FindObjectOfType<GameManager>().swapEnabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)// if detected dark rect collision, enable transition to light
    {
        if (other.gameObject.tag == "DarkRect" || other.gameObject.tag == "LightRect")
        {
            Debug.Log("dark collisioned");
            FindObjectOfType<GameManager>().swapEnabled = true;
            canSwitch = true;

        }
    }
}
