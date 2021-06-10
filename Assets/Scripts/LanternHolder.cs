using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternHolder : MonoBehaviour
{
    public bool occupied;
    
    public Color activeColor = new Color(78, 248, 146, 255);
    SpriteRenderer sr;

    private void Start()
    {
        occupied = false;
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("White Hand"))
        {
            if (occupied != collision.gameObject.GetComponentInChildren<GrabSystem>().holdingLantern)
            {
                sr.color = activeColor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("White Hand"))
        {
            sr.color = Color.white;
        }
    }
}
