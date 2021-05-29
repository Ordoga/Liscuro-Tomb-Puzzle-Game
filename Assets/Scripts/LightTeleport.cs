using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTeleport : MonoBehaviour
{
    GameManager gameManager;
    public GameObject lightPortal;
    public bool startFading = false;
    float intensity = 1f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        lightPortal = FindObjectOfType<GameObject>();
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

    private void Update()
    {
        if (startFading)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white * intensity);
            intensity += Time.unscaledDeltaTime * 2.7f;
        }

    }

    public void LightFade()
    {
        startFading = true;
    }

}
