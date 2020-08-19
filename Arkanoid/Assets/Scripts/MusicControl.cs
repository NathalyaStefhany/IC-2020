using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl musicControl = null;

    private void Awake()
    {
        if(musicControl != null)
        {
            Destroy(gameObject);
        }
        else
        {
            musicControl = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
