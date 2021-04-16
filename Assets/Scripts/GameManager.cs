using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool whiteActive = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whiteActive)
            {
                whiteActive = false;
            }
            else
            {
                whiteActive = true;
            }
        }
    }



}
