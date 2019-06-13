using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;//pausemenu ui the pause menu in essence
    public GameObject Controls_UI;//contols ui needed to make the controls appear and disappear

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();//turn on pause menu
        }
    }
	
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);//activate pause menu

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;//stop game
        }
        else
        {
            Time.timeScale = 1f;//return game to normal speed
            Controls_UI.SetActive(false);
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);//use scene fader to restart scene
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);//use scene fader to go to main menu
    }
    public void Controls()
    {
        if (Controls_UI.activeSelf)
        {
            Controls_UI.SetActive(false);
        }
        else
        {
            Controls_UI.SetActive(true);
        }
    }
}
