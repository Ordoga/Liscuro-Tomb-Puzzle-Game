using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmUp : MonoBehaviour
{
    [SerializeField] float distance = 1f;
    [SerializeField] float fadeIn = 1f;
    [SerializeField] float fadeOut = 1f;
    public Transform lightPlayer;
    public Transform darkPlayer;
    public Transform activationPoint;
    Material material;
    float fade = 0f;
    bool isAppearing = false;
    bool isDisappearing = false;
    bool appeared = false;
    float distanceLight = 0f;
    float distanceDark = 0f;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        distanceLight = Vector2.Distance(lightPlayer.position, activationPoint.position);
        distanceDark = Vector2.Distance(darkPlayer.position, activationPoint.position);

        if (((distanceLight <= distance) || (distanceDark <= distance)) && !appeared)
        {
            isAppearing = true;
            appeared = true;
        }
        
        if (((distanceLight > distance) || (distanceDark > distance)) && appeared)
        {
            isDisappearing = true;
            appeared = false;
        }

        if (isAppearing)
        {
            fade += (Time.deltaTime) / fadeIn;

            if (fade >= 1)
            {
                fade = 1f;
                isAppearing = false;
            }

            material.SetFloat("_fade", fade);
        }
        else if(isDisappearing)
        {
            fade -= (Time.deltaTime) / fadeOut;

            if (fade <= 0)
            {
                fade = 0f;
                isDisappearing = false;
            }

            material.SetFloat("_fade", fade);
        }
        /**
        if (((distanceLight >= 1) || (distanceDark >= 1)) && appeared)
        {
            isDisappearing = true;
            appeared = false;
        }

        if (isDisappearing)
        {
            fade -= (Time.deltaTime) / 2;

            if (fade <= 0)
            {
                fade = 1f;
                isDisappearing = false;
            }

            material.SetFloat("_fade", fade);
        }
        **/
    }
    
}
