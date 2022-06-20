using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenuManager : MonoBehaviour
{
    public GameObject quitConfirm;
    public GameObject opionMenu;
    public GameObject mainMenuButtons;

    public void ChoosingScreenMenu()
    {
        SceneManager.LoadScene("Choosing Level Scene");
    }

    public void PressQuit()
    {
        quitConfirm.SetActive(true);
    }
    public void PressQuitNo()
    {
        quitConfirm.SetActive(false);
    }
    public void PressQuitYes()
    {
        Application.Quit();
    }
    public void PressOption()
    {
        mainMenuButtons.SetActive(false);
        opionMenu.SetActive(true);
    }
    public void PressBack()
    {
        mainMenuButtons.SetActive(true);
        opionMenu.SetActive(false);
    }


}
