using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMovementBlack2D : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 40f;

    Vector2 movement;
    bool jump = false;
    GameManager gameManager;

    private int numOfPlatformsAvailable;
    public Rigidbody2D blackRb;
    public Transform darkPlatform;

    void Start()
    {
        numOfPlatformsAvailable = 3;
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (!gameManager.whiteActive)
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
        if (!gameManager.whiteActive)
        {
            controller.Move(movement.x * moveSpeed * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

}
