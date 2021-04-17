using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTeleport : MonoBehaviour
{


    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightRect"))
        {
            Debug.Log("TELEPORT");
            gameManager.lightPortalReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightRect"))
        {
            gameManager.lightPortalReady = false;
        }
    }
}
