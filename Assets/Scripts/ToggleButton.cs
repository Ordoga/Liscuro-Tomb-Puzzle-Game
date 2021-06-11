using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{

    private Animator anim;
    private GameManager gm;

    void Start()
    {
        this.gameObject.SetActive(true);
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();

    }

    
    void Update()
    {
        anim.SetBool("Light Active", gm.whiteActive);
        anim.SetBool("Swap Enabled", gm.swapEnabled);
        if (gm.levelPassed)
        {
            this.gameObject.SetActive(false);
        }
    }
}
