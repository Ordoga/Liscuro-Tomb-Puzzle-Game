using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlack : MonoBehaviour
{
    Rigidbody2D blackRb;
    Vector3 startingPos;
    private void Start()
    {
        blackRb = GetComponentInParent<Rigidbody2D>();
        startingPos = blackRb.position;
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            Debug.Log("Light collision");
            blackRb.gameObject.GetComponent<DualMovementBlack2D>().frozen = true;
            blackRb.isKinematic = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Uncollide");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            Debug.Log("Uncollide Light");
            blackRb.gameObject.GetComponent<DualMovementBlack2D>().frozen = false;
            blackRb.isKinematic = false;
        }
    }


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
    }

}
