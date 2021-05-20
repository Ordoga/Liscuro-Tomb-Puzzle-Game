using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlack : MonoBehaviour
{
    [SerializeField] Sprite alarmed, relaxed;

    //all the timer related variables
    [SerializeField] float timeAllowInFreeze = 4.0f;
    private float timerInFreeze;
    private bool activateTimer;

    Rigidbody2D blackRb;
    Vector3 startingPos;

    float fade = 1f;
    public GameObject darkSprite;

    private void Start()
    {
        darkSprite = FindObjectOfType<DualMovementBlack2D>().gameObject;
        activateTimer = false;
        blackRb = GetComponentInParent<Rigidbody2D>();
        startingPos = blackRb.position;
        timerInFreeze = timeAllowInFreeze;
        darkSprite.GetComponent<SpriteRenderer>().material.SetFloat("_fade", 1);
    }

    private void Update()
    {
        //if dark rect is freezed - timer activates
        if (activateTimer)
        {
            fade -= (Time.deltaTime/5);

            if (fade <= 0)
            {
                MoveToStartingPos();
            }
            else
            {
                darkSprite.GetComponent<SpriteRenderer>().material.SetFloat("_fade", fade);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            activateTimer = true;

            Debug.Log("Light collision");
            blackRb.gameObject.GetComponent<DualMovementBlack2D>().frozen = true;
            blackRb.isKinematic = true;
            blackRb.gameObject.GetComponent<SpriteRenderer>().sprite = alarmed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Uncollide");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            activateTimer = false;
            fade = 1f;
            darkSprite.GetComponent<SpriteRenderer>().material.SetFloat("_fade", fade);
            timerInFreeze = timeAllowInFreeze;

            Debug.Log("Uncollide Light");
            blackRb.gameObject.GetComponent<DualMovementBlack2D>().frozen = false;
            blackRb.isKinematic = false;
            blackRb.gameObject.GetComponent<SpriteRenderer>().sprite = relaxed;
        }
        //If the black rect leaves the map boundaries, teleport back to starting position
        if (collision.gameObject.CompareTag("Confiner"))
        {
            Debug.Log("Left Map");
            MoveToStartingPos();
        }          
    }

    //move black rect to the starting position
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tilemap"))
        {
            MoveToStartingPos();
        }
    }

    private void MoveToStartingPos()
    {
        Debug.Log("MoveToStart");
        blackRb.position = startingPos;
        fade = 1;
    }

}
