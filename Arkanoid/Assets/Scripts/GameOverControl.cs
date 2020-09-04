using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    private SceneControl sceneControl;
    private AddScore addScore;

    private void Start()
    {
        sceneControl = GameObject.FindObjectOfType<SceneControl>();
        addScore = GameObject.FindObjectOfType<AddScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = PlayerPrefs.GetString("Name");
        int round = Convert.ToInt32(PlayerPrefs.GetString("Level"));
        int points = Convert.ToInt32(PlayerPrefs.GetString("Points"));

        addScore.AddHighScoreEntry(name, round, points);

        sceneControl.CallScenes("GameOver");
    }
}
