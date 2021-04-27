using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DarkTilesUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DarkTilesText;
    private BuildSystem buildSystem; //SetDarkTiles script to get reference to num of available tiles
    private int availableNumOfDarkTiles;
      

    void Start()
    {
        buildSystem = FindObjectOfType<BuildSystem>();
        availableNumOfDarkTiles = buildSystem.availablePlatformsNum;
    }

    void Update()
    {
        availableNumOfDarkTiles = buildSystem.availablePlatformsNum;
        DarkTilesText.text = "x " + availableNumOfDarkTiles.ToString();
    }
}
