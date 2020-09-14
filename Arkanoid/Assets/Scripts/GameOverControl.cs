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

    private void Start()
    {
        sceneControl = GameObject.FindObjectOfType<SceneControl>();
        addScore = GameObject.FindObjectOfType<AddScore>();
        lives = GameObject.FindObjectOfType<Lives>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool gameOver = lives.TakeLife();

        if (gameOver)
        {
            string name = PlayerPrefs.GetString("Name");
            int round = Convert.ToInt32(PlayerPrefs.GetString("Level"));
            int points = Convert.ToInt32(PlayerPrefs.GetString("Points"));

            addScore.AddHighScoreEntry(name, round, points);

            Block.destructibleBlockNum = 0;

            sceneControl.CallScenes("GameOver");
        }
        else
        {
            ball.setGameStarted(false);
        }
    }
}
