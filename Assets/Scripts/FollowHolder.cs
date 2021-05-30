using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowHolder : MonoBehaviour
{
    public bool pickedUp;
    public Transform holderTransform;
    public Color activeColor = new Color(78, 248, 146, 255);


    [SerializeField] float force = 1.5f;

    Vector2 dir;
    Vector2 normalDir;
    SpriteRenderer sr;
    Rigidbody2D rb;
    bool soundPlayed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        soundPlayed = false;
    }

    void Update()
    {
        sr.sortingOrder = holderTransform.GetComponent<SpriteRenderer>().sortingOrder; // equals the sorting order of the light's hand

        if (pickedUp)
        {
            transform.position = holderTransform.position; // Follows holder
            if (!soundPlayed)
            {
                GetComponent<AudioSource>().Play(0);
                soundPlayed = true;
            }
        }
        else
        {
            if (soundPlayed)
            {
                GetComponent<AudioSource>().Play(0);
                soundPlayed = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("White Hand"))
        {
            if (!pickedUp && !collision.gameObject.GetComponentInChildren<GrabSystem>().holdingLantern)
            {
                sr.color = activeColor;
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("White Hand"))
        {
            sr.color = Color.white;
        }
    }

}
