using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public string nextLevel = "Level2";//put in unity
    public int levelToUnlock = 2;//put in unity


    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
