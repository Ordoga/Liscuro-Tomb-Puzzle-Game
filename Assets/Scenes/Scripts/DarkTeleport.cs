using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTeleport : MonoBehaviour
{
    GameManager gameManager;
    public GameObject darkPortal;
    public bool startFading = false;
    float intensity = 1f;


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

    private void Update()
    {
        if (startFading)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white * intensity);
            intensity += Time.unscaledDeltaTime * 4f;
        }

    }

    public void DarkFade()
    {
        startFading = true;
    }

}
