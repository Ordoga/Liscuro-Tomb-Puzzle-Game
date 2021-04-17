using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTeleport : MonoBehaviour
{

    //public bool enteredDark;

    GameManager gameManager;

    void Start()
    {
        //enteredDark = false;
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightRect"))
        {
            Debug.Log("TELEPORT");
            gameManager.lightPortalReady = true;
        }
        /* if (Vector2.Distance(transform.position, collision.transform.position) > 0.2f)
         {
             Player.transform.position = new Vector2(teleportpoint.position.x,teleportpoint.position.y);
             //Debug.Log("TELEPORT");
         }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightRect"))
        {
            gameManager.lightPortalReady = false;
        }
    }
}
