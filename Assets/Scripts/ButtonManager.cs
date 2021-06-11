using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour
{
    public int buttonNum;
    public int imageNum;

    /*public Sprite zero; //lockImg
    public Sprite one; //two star
    public Sprite two; //one star
    public Sprite three; //three star
    */

    public Sprite[] imageList;

    Image imgToSwitch;

    // Start is called before the first frame update
    void Start()
    {
        imgToSwitch = GetComponent<Image>();
        imageNum = 0;

    }
    void Update()
    {
        
        //of this level is higher than the levelreached - put lock image
        if(PlayerPrefs.GetInt("levelReached", 1) < buttonNum)
        {
            imageNum = 0;

        }
        //if i didnt start this level but reached put the eye open image 
        if ((PlayerPrefs.GetInt("levelReached", 1) == buttonNum))
        {
            imageNum = 1;

        }

        //check if this level which connected to the button is finished
        if (PlayerPrefs.GetInt("Level " + buttonNum + " completion", 0) == 1)
        {
            imageNum = 2;
        }
        //check if the number of switches of this level has passed the low requirement of switching
        if (PlayerPrefs.GetInt("Level " + buttonNum + " notBestNumOfSwitches", 0) == 1)
        {
            imageNum = 3;
        }
        //check if the number of switches of this level has passed the best requirement of switching
        if (PlayerPrefs.GetInt("Level " + buttonNum + " bestNumOfSwitches", 0) == 1)
        {
            imageNum = 4;
            Debug.Log(PlayerPrefs.GetInt("Level " + buttonNum + " bestNumOfSwitches", 0));
        }
        //Debug.Log(imageNum);

        imgToSwitch.sprite = imageList[imageNum];
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(buttonNum);
        
    }

}

