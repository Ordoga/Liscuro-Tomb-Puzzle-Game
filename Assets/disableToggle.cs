using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableToggle : MonoBehaviour
{
    public bool toggleOn;
    public GameObject toggleBar;
    // Update is called once per frame
    void Update()
    {

        if (toggleOn)
        {
            toggleBar.SetActive(true);
        }
        else
        {
            toggleBar.SetActive(false);
        }
    }
}
