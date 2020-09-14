using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private int playerLives;
    public Font font;
    void Start()
    {
        playerLives = PlayerPrefs.GetInt("Lives");
    }

    public bool TakeLife()
    {
        playerLives--;

        if (playerLives <= 0)
        {
            return true;
        }

        return false;
    }

    void OnGUI()
    {
        GUI.skin.font = font;
        GUI.skin.label.fontSize = Screen.height / 8;

        float posX = 0.03f * Screen.width;
        float posY = 0.01f * Screen.height;

        GUI.Label(new Rect(posX, posY, 200.0f, 200.0f), "LIVES: " + playerLives);
    }

    public int getPlayerLives()
    {
        return playerLives;
    }
}
