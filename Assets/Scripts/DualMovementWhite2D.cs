using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMovementWhite2D : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;
    [SerializeField] float moveSpeed = 40f;

    Vector2 movement;
    bool jump = false;
    GameManager gameManager;
    Rigidbody2D rb;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gameManager.haltWhite)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        if (gameManager.whiteActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    jump = true;
                }
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.whiteActive) {
            controller.Move(movement.x * moveSpeed * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

}
