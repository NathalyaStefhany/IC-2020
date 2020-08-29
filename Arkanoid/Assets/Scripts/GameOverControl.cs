using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    private SceneControl sceneControl;
    private HighScoreTable highScoreTable;

    private void Start()
    {
        sceneControl = GameObject.FindObjectOfType<SceneControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneControl.CallScenes("GameOver");
    }
}
