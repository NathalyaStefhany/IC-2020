using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public void AddHighScoreEntry(string name, int round, int score)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { name = name, round = round, score = score };

        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        string json;

        if (string.IsNullOrEmpty(jsonString) == true)
        {
            HighScores highScores = new HighScores();
            highScores.highScoreEntryList = new List<HighScoreEntry>();

            highScores.highScoreEntryList.Add(highScoreEntry);

            json = JsonUtility.ToJson(highScores);

            PlayerPrefs.SetString("HighScoreTable", json);
            PlayerPrefs.Save();
        }
        else
        {
            HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

            highScores.highScoreEntryList.Add(highScoreEntry);

            highScores.highScoreEntryList.Sort(delegate (HighScoreEntry x, HighScoreEntry y)
            {
                if (x.score.CompareTo(y.score) == 0) return x.name.CompareTo(y.name);
                return x.score.CompareTo(y.score) * -1;
            });

            if (highScores.highScoreEntryList.Count > 5)
            {
                highScores.highScoreEntryList.RemoveAt(5);
            }

            json = JsonUtility.ToJson(highScores);

            PlayerPrefs.SetString("HighScoreTable", json);
            PlayerPrefs.Save();
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
}
