using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LightTextUp : MonoBehaviour
{
    public Transform player;
    Material material;
    float fade = 0f;
    bool isAppearing = false;
    bool appeared = false;
    float distance = 0f;
    float fresnel = 10f;
    float fresnelSign = -1f;
    Color color = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        material = GetComponent<Text>().material;
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
            material.SetColor("_Color", Color.white);
        }
    }
}
