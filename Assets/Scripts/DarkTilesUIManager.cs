using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DarkTilesUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DarkTilesText;
    private SetDarkTile setDarkTile; //SetDarkTiles script to get reference to num of available tiles
    private int availableNumOfDarkTiles;
      

    void Start()
    {
        setDarkTile = FindObjectOfType<SetDarkTile>();
        availableNumOfDarkTiles = setDarkTile.availablePlatformsNum;
    }

    void Update()
    {
        availableNumOfDarkTiles = setDarkTile.availablePlatformsNum;
        DarkTilesText.text = "x " + availableNumOfDarkTiles.ToString();
    }
}
