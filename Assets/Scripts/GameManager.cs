using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool whiteActive = true;
    public bool lightPortalReady = false;
    public bool darkPortalReady = false;
    public bool levelPassed = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whiteActive)
            {
                whiteActive = false;
            }
            else
            {
                whiteActive = true;
            }
        }
        if (lightPortalReady && darkPortalReady)
        {
            levelPassed = true;
            lightPortalReady = false;
            darkPortalReady = false;
        }
    }



}
