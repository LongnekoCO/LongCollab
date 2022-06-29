using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenu;

    public GameObject restartConfirm;

    public GameObject quitConfirm;

    Scene curScene;
    void Start()
    {
        
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ConfirmRestartLevel()
    {
        restartConfirm.SetActive(true);
    }
    public void NotConfirmRestartLevel()
    {
        restartConfirm.SetActive(false);
    }
    public void ConfirmQuit()
    {
        quitConfirm.SetActive(true);
    }
    public void NotConfirmQuit()
    {
        quitConfirm.SetActive(false);
    }

    public void Out()
    {
        Application.Quit();
    }
}
