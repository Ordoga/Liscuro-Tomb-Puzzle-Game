using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMovementBlack2D : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 40f;
    public bool frozen = false;

    Vector2 movement;
    bool jump = false;
    GameManager gameManager;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("White active", gameManager.whiteActive);
        if (gameManager.haltBlack)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        if (!gameManager.whiteActive && !frozen)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown("space"))
            {
                jump = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (!gameManager.whiteActive && !frozen)
        {
            controller.Move(movement.x * moveSpeed * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }


}
