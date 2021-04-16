using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTestingMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] bool isActive = true;

    Vector2 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

        }
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
