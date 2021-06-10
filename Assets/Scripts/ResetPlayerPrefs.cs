using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{

    public void resetPrefs() // resets all player's progress
    {
        PlayerPrefs.DeleteAll();
    }


}
