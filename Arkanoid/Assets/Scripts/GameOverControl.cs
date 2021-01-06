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
    private Ball[] balls;
    private Score score;

    private void Start()
    {
        addScore = new AddScore();

        sceneControl = GameObject.FindObjectOfType<SceneControl>();
        lives = GameObject.FindObjectOfType<Lives>();
        balls = GameObject.FindObjectsOfType<Ball>();
        score = GameObject.FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        balls = GameObject.FindObjectsOfType<Ball>();
        
        if (balls.Length == 1)
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
                Platform platform = GameObject.FindObjectOfType<Platform>();

                balls[0].setPlatformBallDis(new Vector3(platform.transform.position.x, (float)-3.6, 0) - platform.transform.position);
                balls[0].setGameStarted(false);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}