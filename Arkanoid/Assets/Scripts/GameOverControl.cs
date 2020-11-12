using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    private SceneControl sceneControl;
    private AddScore addScore;
    private Lives lives;
    private Ball ball;
    private Score score;

    private void Start()
    {
        sceneControl = GameObject.FindObjectOfType<SceneControl>();
        addScore = GameObject.FindObjectOfType<AddScore>();
        lives = GameObject.FindObjectOfType<Lives>();
        ball = GameObject.FindObjectOfType<Ball>();
        score = GameObject.FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives.TakeLife();

        if (lives.getPlayerLives() == 0)
        {
            string name = PlayerPrefs.GetString("Name");
            int round = Convert.ToInt32(PlayerPrefs.GetString("Level"));
            int points = score.getPlayerPoints();

            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("CurrentScore", 0);

            addScore.addHighScoreEntry(name, round, points);

            Block.destructibleBlockNum = 0;

            sceneControl.CallScenes("GameOver");
        }
        else
        {
            ball.setGameStarted(false);
        }
    }
}