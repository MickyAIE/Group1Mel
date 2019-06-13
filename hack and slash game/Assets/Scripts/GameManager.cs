using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //look into textmeshpro - text
    public static bool GameIsOver;//is game over

    public GameObject gameOverUI;//what shows when game over
    public GameObject completeLevelUI;//what show when level complete
    public SceneFader sceneFader;//scene fader check scene fader script

    private void Start()
    {
        GameIsOver = false;//game not over

        Time.timeScale = 1f;//speed set to normal
    }

    void Update()
    {
        if (GameIsOver)
            return;
    }
    
    void EndGame()
    {
        GameIsOver = true;//game is over

        gameOverUI.SetActive(true);//show game over ui
    }

    public void WinLevel()
    {
        GameIsOver = true;//game is over
        completeLevelUI.SetActive(true);//show level complete ui
    }

}
