using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, Observer
{
    private int playerPoints;
    public Font font;
   
    Observable[] observables;

    void Start()
    {
        playerPoints = PlayerPrefs.GetInt("CurrentScore");
    
        observables = GameObject.FindObjectsOfType<Block>();
       
        foreach (Observable obs in observables)
            obs.RegisterObserver(this);
    }

    public void update(object observable)
    {
        Block block = (Block)observable;

        playerPoints += block.points;
    }

    void OnGUI()
    {
        GUI.skin.font = font;
        GUI.skin.label.fontSize = Screen.height / 8;

        float posX = 0.80f * Screen.width;
        float posY = 0.01f * Screen.height;

        GUI.Label(new Rect(posX, posY, 200.0f, 200.0f), "SCORE: " + playerPoints);
    }

    public int getPlayerPoints()
    {
        return playerPoints;
    }
}
