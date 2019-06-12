using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //look into textmeshpro - text
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public SceneFader sceneFader;

    private void Start()
    {
        GameIsOver = false;

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (GameIsOver)
            return;
    }
    
    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
