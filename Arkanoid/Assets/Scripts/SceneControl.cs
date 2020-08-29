using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void CallScenes(string nameScene)
    {
        if(nameScene == "Level1")
            PlayerPrefs.SetString("Level", "1");

        SceneManager.LoadScene(nameScene);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DestroyedBlock()
    {
        if(Block.destructibleBlockNum <= 0)
        {
            int level = Convert.ToInt32(PlayerPrefs.GetString("Level")) + 1;
            
            PlayerPrefs.SetString("Level", level.ToString());

            LoadNextLevel();
        }
    }
}
