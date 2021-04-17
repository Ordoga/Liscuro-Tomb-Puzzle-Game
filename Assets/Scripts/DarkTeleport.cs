using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTeleport : MonoBehaviour
{

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DarkRect"))
        {
            Debug.Log("TELEPORT");
            gameManager.darkPortalReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DarkRect"))
        {
            gameManager.darkPortalReady = false;
        }
    }

}
