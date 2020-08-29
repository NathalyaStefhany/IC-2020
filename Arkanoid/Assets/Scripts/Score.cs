﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int playerPoints;
    public Font font;

    void Start()
    {
        playerPoints = 0;
    }

    public void addPoints(int points)
    {
        playerPoints += points;

        PlayerPrefs.SetString("Points", playerPoints.ToString());
    }

    void OnGUI()
    {
        GUI.skin.font = font;
        GUI.skin.label.fontSize = Screen.height / 8;

        float posX = 0.80f * Screen.width;
        float posY = 0.01f * Screen.height;

        GUI.Label(new Rect(posX, posY, 200.0f, 200.0f), "SCORE: " + playerPoints);
    }
}
