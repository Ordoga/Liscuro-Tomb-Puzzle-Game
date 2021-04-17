using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTeleport : MonoBehaviour
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
        if (other.gameObject.CompareTag("DarkRect"))
        {
            Debug.Log("TELEPORT");
            gameManager.darkPortalReady = true;
        }
        /* if (Vector2.Distance(transform.position, collision.transform.position) > 0.2f)
         {
             Player.transform.position = new Vector2(teleportpoint.position.x,teleportpoint.position.y);
             //Debug.Log("TELEPORT");
         }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DarkRect"))
        {
            gameManager.darkPortalReady = false;
        }
    }

}
