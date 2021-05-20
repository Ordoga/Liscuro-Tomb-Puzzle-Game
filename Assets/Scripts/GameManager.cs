using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool whiteActive = true;
    public bool lightPortalReady = false;
    public bool darkPortalReady = false;
    public bool levelPassed = false;
    public bool haltWhite = false;
    public bool haltBlack = false;

    




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

        rectSwitchCounter = 0;
        darkTilesPlaceCounter = 0;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
          


            if (whiteActive) //make black active
            {
                whiteActive = false;
                haltWhite = true;
            }
            else            //make white active
            {
                whiteActive = true;
                haltBlack = true;
            }
            rectSwitchCounter++;
            Debug.Log(rectSwitchCounter);
        }

        if (lightPortalReady && darkPortalReady)
        {
            levelFinished();
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
        Debug.Log("previousNumOfDtPlacements"+ previousNumOfDtPlacements);

        //get a star for the current level completed
        PlayerPrefs.SetInt("Level " + currentSceneIndex + " completion",1);

        levelPassed = true;
        lightPortalReady = false;
        darkPortalReady = false;

    }



}
