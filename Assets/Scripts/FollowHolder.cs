using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowHolder : MonoBehaviour
{
    public bool pickedUp;
    public Transform holderTransform;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 1.5f;

    Vector2 dir;
    Vector2 normalDir;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (pickedUp)
        {
            transform.position = holderTransform.position; // Follows holder
            /**
            dir = holderTransform.position - rb.transform.position ;
            normalDir = dir;
            normalDir.Normalize();
            float magnitude = dir.magnitude;
            Vector2 adaptiveDir = 2f * math.atan(0.3f * magnitude) / math.PI * normalDir;
            rb.AddForce(adaptiveDir);
            **/
            
        }
    }
}
