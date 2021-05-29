using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    Animator animator;
    GameManager gm;
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        animator.SetBool("Light Active", gm.whiteActive);
        animator.SetBool("Swap Enabled", gm.swapEnabled);
    }
}
