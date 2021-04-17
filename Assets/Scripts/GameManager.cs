using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool whiteActive = true;
    public bool lightPortalReady = false;
    public bool darkPortalReady = false;


    /*private DarkTeleport darkTeleport = FindObjectOfType<DarkTeleport>();
    private LightTeleport lightTeleport = FindObjectOfType<LightTeleport>();*/



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
            Debug.Log("NEXTSTAGE");
            lightPortalReady = false;
            darkPortalReady = false;
        }
    }



}
