using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public string menuSceneName = "MainMenu";//name main menu this for this to work

    public SceneFader sceneFader;

   
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);//cause level to restart
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);//go to main menu
    }

}
