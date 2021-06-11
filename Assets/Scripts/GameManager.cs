using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource gameComplete1, gameComplete2, swapSound;

    public bool whiteActive = true;
    public bool lightPortalReady = false;
    public bool darkPortalReady = false;
    public bool levelPassed = false;
    public bool haltWhite = false;
    public bool haltBlack = false;
    public bool cursor = false;

    public bool whiteStarts;


    public bool swapEnabled;



    //Challenge System cotext
    public int rectSwitchCounter;
    public int darkTilesPlaceCounter;

    public int previousNumOfSwitches;
    public int previousNumOfDtPlacements;

    public int currentLevel;
    public int currentSceneIndex;

    public string placement;
    public string switches;

    private void Start()
    {
       
        whiteActive = whiteStarts;

        rectSwitchCounter = 0;
        darkTilesPlaceCounter = 0;
        Cursor.visible = cursor;

    }
    private void Update()
    {

        if (haltBlack)      //release black's movement
        {
            haltBlack = false;
        }

        if (haltWhite)      //release white's movement
        {
            haltWhite = false;
        }

        if (Input.GetKeyDown("left shift") && swapEnabled) // if i can move between characters
        {
                swapSound.Play(0);
                if (whiteActive) //make black active
                {
                    whiteActive = false;
                    haltWhite = true;

                }
                else   //if dark active
                {
                    whiteActive = true;
                    haltBlack = true;
                }
                rectSwitchCounter++;

        }

        if (lightPortalReady && darkPortalReady)
        {
            levelFinished();
            gameComplete1.Play(0);
            gameComplete2.Play(0);
        }

    }

    public void levelFinished()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        placement = "Level " + currentSceneIndex + " placements";
        switches = "Level " + currentSceneIndex + " switches";

        previousNumOfSwitches = PlayerPrefs.GetInt(switches, rectSwitchCounter);
        previousNumOfDtPlacements = PlayerPrefs.GetInt(placement, darkTilesPlaceCounter);


        //if the default value assigned, set it to the playerpref
        if (previousNumOfSwitches == rectSwitchCounter)
        {
            PlayerPrefs.SetInt(switches, rectSwitchCounter);
        }

        if (previousNumOfDtPlacements == darkTilesPlaceCounter)
        {
            PlayerPrefs.SetInt(placement, darkTilesPlaceCounter);
        }
        //player.prefs hold the level reached so we check if we passed the level before the level we want to unlock (we get the scene build index)

        if (PlayerPrefs.GetInt("levelReached", 1) < SceneManager.GetActiveScene().buildIndex + 1)  
        {
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex + 1);
        }
        //check if the player improved his number of rect switches - if yes update player.pref
        if ((previousNumOfSwitches > rectSwitchCounter)){ 
             
            PlayerPrefs.SetInt(switches, rectSwitchCounter);
        
        }
        //check if the player improved his number of DT placements - if yes update player.pref
        if ((previousNumOfDtPlacements > darkTilesPlaceCounter))
        {
            PlayerPrefs.SetInt(placement, darkTilesPlaceCounter);
        }


        //get a star for the current level completed
        PlayerPrefs.SetInt("Level " + currentSceneIndex + " completion",1);

        levelPassed = true;
        lightPortalReady = false;
        darkPortalReady = false;

    }



}
