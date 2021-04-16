using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int currencyEffect = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Dark Player"))
        {
            CurrencyManager.instance.ChangeOrbAmount(currencyEffect);
        }

    }
}
