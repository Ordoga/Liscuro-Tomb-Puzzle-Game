using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // public SceneFader fader;

    //buttons array
    public Button[] levelButtons;



    //the data of each level about how many switches/dt placements achieved by the best run -> index i == level i , starting from 1
    //CHANGE THE LENGTH ACCORDING TO NUMBER OF LEVELS+1
    private int[] levelSwitches = new int[10];
    private int[] levelDtPlacements = new int[10];

    /* Two dimensional array contains all the desired requirements for each stage 
    First index is the number of levels+1 and the second is 3 according to This level requirements - 
    First for complete stage - 1 
    Second for the less desired number of switches between charachters
    Third for the desired number of switches between charachters */

    public int[,] levelRequirements = new int[10, 2] {
        /*dummyCell*/{0,0},
        {3,1},
        {4,2},
        {3,2},
        {4,2},
        {3,1},
        {4,2},
        {7,4},
      /*change*/  {5,5},
     /*change*/   {5,5 }
    };

  


    //updates all the open levels every time we visit levels menu
    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 1; i < levelButtons.Length+1; i++)
        {

            if (i  > levelReached) //locks all levels above the level reached
            {
                levelButtons[i-1].interactable = false;

            }
            else //for all the levels which are open level 0 is not defined
            {
                levelSwitches[i] = PlayerPrefs.GetInt("Level " + i + " switches", 1000); 
                levelDtPlacements[i] = PlayerPrefs.GetInt("Level " + i + " placements", 1000);

                
                //if the number of switches is less or equal than the best requirement
                if(levelSwitches[i] <= levelRequirements[i,1])
                {
                  
                    PlayerPrefs.SetInt("Level " + i + " bestNumOfSwitches", 1);
                    
                }
                else
                {
                    PlayerPrefs.SetInt("Level " + i + " bestNumOfSwitches", 0);
                }
                //if the number of switches is less or equal than the less desired requirement
                if (levelSwitches[i] <= levelRequirements[i,0])
                {
                    PlayerPrefs.SetInt("Level " + i + " notBestNumOfSwitches", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Level " + i + " notBestNumOfSwitches", 0);

                }
            }

        }


    }


    public void Select(string levelName)
    {
        //fader.FadeTo(levelName);
    }
}
