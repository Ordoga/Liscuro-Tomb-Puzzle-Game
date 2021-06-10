using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchToMainMenu : MonoBehaviour
{
    private int mainMenuIdx = 0;

    public void MainMenuScene()
    {
        SceneManager.LoadScene(mainMenuIdx);
    }
}
