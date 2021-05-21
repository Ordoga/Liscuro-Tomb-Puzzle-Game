using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{

    public bool holdingLantern;

    [SerializeField] Rigidbody2D grabDetect;
    [SerializeField] LayerMask lanternsLayer, holdersLayer;
    [SerializeField] Sprite redHand;
    [SerializeField] Sprite RegularHand;


    float detectRadius;
    bool holderNearby;
    GameObject closestHolder;
    Collider2D collision, hangerCollision;
    GameManager gameManager;

    private SpriteRenderer spriteRd;

    void Start()
    {
        spriteRd = GetComponent<SpriteRenderer>();
        spriteRd.sortingOrder = 5;
        holderNearby = false;
        holdingLantern = false;
        detectRadius = GetComponent<CircleCollider2D>().radius + .05f;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

        if (holdingLantern)
        {
            spriteRd.sortingOrder = 11; //if holding lantern show the hand infront of light character
        }
        else
        {
            spriteRd.sortingOrder = 5; //if not holding lantern show the hand in the back of light character

        }

        if (gameManager.whiteActive && Input.GetKeyDown(KeyCode.Mouse0)) // Left mouse clicked
        {
            FindLanternsAndHangers();

            if (collision != null && !holdingLantern)     // If a lantern object was detected
            {
                PickUpLantern();
            }
            else
            {
                if (hangerCollision != null && holdingLantern) // If found a holder and holding lantern
                {
                    closestHolder = hangerCollision.gameObject;
                    if (!closestHolder.GetComponent<LanternHolder>().occupied) // If holder is vacant
                    {
                        PlaceLantern();
                    }
                }
            }
        }
    }   

    private void FindLanternsAndHangers()
    {
        collision = Physics2D.OverlapCircle(grabDetect.position, detectRadius, lanternsLayer);
        hangerCollision = Physics2D.OverlapCircle(grabDetect.position, detectRadius, holdersLayer);
        if(hangerCollision != null)
        {
            holderNearby = true;
            closestHolder = hangerCollision.gameObject;
        }
        else
        {
            holderNearby = false;
        }
    }
    private void PickUpLantern()
    {
        if (holderNearby) // Pick up lantern from holder
        {
            closestHolder.GetComponent<LanternHolder>().occupied = false;
        }
        collision.GetComponent<FollowHolder>().pickedUp = true;
        collision.GetComponent<FollowHolder>().holderTransform = this.grabDetect.transform;
        //collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        holdingLantern = true;
    }

    private void PlaceLantern()
    {
        closestHolder.GetComponent<LanternHolder>().occupied = true;
        collision.transform.position = closestHolder.transform.position;
        collision.GetComponent<FollowHolder>().pickedUp = false;
        //collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        holdingLantern = false;
    }

}
