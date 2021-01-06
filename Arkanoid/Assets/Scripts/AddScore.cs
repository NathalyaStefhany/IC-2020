using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore 
{
    public void addHighScoreEntry(string name, int round, int score)
    {
        HighScores highScores;
        HighScoreEntry highScoreEntry = new HighScoreEntry { name = name, round = round, score = score };
        
        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        string json;

        if (string.IsNullOrEmpty(jsonString))
        {
            highScores = new HighScores();
            highScores.highScoreEntryList = new List<HighScoreEntry>();
        }
        else
            highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.highScoreEntryList.Add(highScoreEntry);

        highScores = sortScore(highScores);

        if (highScores.highScoreEntryList.Count > 5)
        {
            highScores.highScoreEntryList.RemoveAt(5);
        }

        json = JsonUtility.ToJson(highScores);

        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
    }

    public HighScores sortScore(HighScores highScores)
    {
        highScores.highScoreEntryList.Sort(delegate (HighScoreEntry x, HighScoreEntry y)
        {
            if (x.score.CompareTo(y.score) == 0) return x.name.CompareTo(y.name);
            return x.score.CompareTo(y.score) * -1;
        });
        
        return highScores;
    }
}

public class HighScores
{
    public List<HighScoreEntry> highScoreEntryList;
}

[System.Serializable]
public class HighScoreEntry
{
    public string name;
    public int round;
    public int score;
}