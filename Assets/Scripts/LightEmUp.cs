using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmUp : MonoBehaviour
{
    public Transform player;
    Material material;
    float fade = 0f;
    bool isAppearing = false;
    bool appeared = false;
    float distance = 0f;
    float fresnel = 10f;
    float fresnelSign = -1f;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);

        if (distance <= 1 && !appeared)
        {
            isAppearing = true;
            appeared = true;
        }

        if (isAppearing)
        {

            fade += (Time.deltaTime) / 3;

            if (fade >= 1)
            {
                fade = 1f;
                isAppearing = false;
            }

            material.SetFloat("_fade", fade);
        }
        
    }
    
}
