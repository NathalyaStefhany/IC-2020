using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void CallScenes(string nameScene)
    {
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
            LoadNextLevel();
        }
    }
}
