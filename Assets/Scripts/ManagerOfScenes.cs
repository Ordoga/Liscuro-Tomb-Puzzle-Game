using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfScenes : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject NextLevelUi;
    public GameObject pauseMenuUi;
    public GameManager gameManager;

    void Update()
    {
        if (gameManager.levelPassed)
        {
            PassPause();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PassPause()
    {
        NextLevelUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ChooseLevel()
    {
        SceneManager.LoadScene("Levels");
    }
    public void LevelRestrictions()
    {

    }
}
