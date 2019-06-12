using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public string menuSceneName = "MainMenu";
    public string credits = "Credits";

    public SceneFader sceneFader;


    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit ()
    {
        Debug.Log("Exciting....");
        Application.Quit();
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Credits()
    {
        sceneFader.FadeTo(credits);
    }
}
