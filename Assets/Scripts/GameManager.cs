using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool whiteActive = true;
    public bool lightPortalReady = false;
    public bool darkPortalReady = false;
    public bool levelPassed = false;
    public bool haltWhite = false;
    public bool haltBlack = false;


    private void Update()
    {

        if (haltBlack)      //release black's movement
        {
            haltBlack = false;
        }

        if (haltWhite)      //release white's movement
        {
            haltWhite = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whiteActive) //make black active
            {
                whiteActive = false;
                haltWhite = true;
            }
            else            //make white active
            {
                whiteActive = true;
                haltBlack = true;
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
