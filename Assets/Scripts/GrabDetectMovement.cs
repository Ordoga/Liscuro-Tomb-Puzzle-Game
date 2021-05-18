using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GrabDetectMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D holderRb;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;
    
    float maxDistFromHolder = 1.8f;
    Vector2 mousePos;

    private void Start()
    {
        //cam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        
        Vector2 normalLookDir = mousePos - holderRb.position;
        Vector2 lookDir = normalLookDir;
        float magnitude = lookDir.magnitude;
        lookDir.Normalize();
        Vector2 adaptiveLookDir = 2f * math.atan(0.4f * magnitude) / math.PI * lookDir;
        rb.position = holderRb.position + maxDistFromHolder * adaptiveLookDir;
    }

}
