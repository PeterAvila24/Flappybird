using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public bool GOver = false;


    void Start()
    {
        // Load the high score from PlayerPrefs when the game starts
        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreTAdd)
    {

        playerScore = playerScore + scoreTAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            
           
         
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        GOver = true;
        UpdateHighScoreText ();
        
    }

  void UpdateHighScoreText()
    {
       


        highScoreText.text = "High Score: " + highScore.ToString();
    }

}
