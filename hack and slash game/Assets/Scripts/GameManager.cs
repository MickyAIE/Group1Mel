using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //look into textmeshpro - text
    public bool GameIsOver;//is game over

    public GameObject gameOverUI;//what shows when game over
    public GameObject completeLevelUI;//what show when level complete
    public SceneFader sceneFader;//scene fader check scene fader script
    public GameObject[] m_enemies;

    public void Awake()
    {
        //get all enemy with enemy tag so i dont have to put in each enemy in unity
    }

    private void Start()
    {
        GameIsOver = false;//game not over

        Time.timeScale = 1f;//speed set to normal
    }
    private bool NoEnemies()
    {
        int numenemsLeft = 0;

        for (int i = 0; i < m_enemies.Length; i++)
        {
            if (m_enemies[i].activeSelf == true)
            {
                numenemsLeft++;
            }
        }
        return numenemsLeft <= 0;
    }

    void Update()
    {
        if(NoEnemies() == true)
        {
            WinLevel();
        }

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
