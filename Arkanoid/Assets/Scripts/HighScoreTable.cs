using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;  
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string name = PlayerPrefs.GetString("Name");
        int points = Convert.ToInt32(PlayerPrefs.GetString("Points"));
        int round = Convert.ToInt32(PlayerPrefs.GetString("Level"));

        string jsonString = PlayerPrefs.GetString("HighScoreTable");

        if (string.IsNullOrEmpty(jsonString) == true)
        {
            HighScoreEntry highScoreEntry = new HighScoreEntry();

            highScoreEntry.name = "None";
            highScoreEntry.round = 0;
            highScoreEntry.score = 0;

            string json = JsonUtility.ToJson(highScoreEntry);

            PlayerPrefs.SetString("HighScoreTable", json);
            PlayerPrefs.Save();


        }
        
        AddHighScoreEntry(name, round, points);

        jsonString = PlayerPrefs.GetString("HighScoreTable");

        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScoreEntryTransformList = new List<Transform>();

        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 100f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("Name").GetComponent<Text>().text = highScoreEntry.name;
        entryTransform.Find("Round").GetComponent<Text>().text = highScoreEntry.round.ToString();
        entryTransform.Find("Score").GetComponent<Text>().text = highScoreEntry.score.ToString();

        transformList.Add(entryTransform);
    }

    private void AddHighScoreEntry(string name, int round, int score)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { name = name, round = round, score = score };

        string jsonString = PlayerPrefs.GetString("HighScoreTable");

        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.highScoreEntryList.Add(highScoreEntry);

        highScores.highScoreEntryList.Sort(delegate (HighScoreEntry x, HighScoreEntry y)
        {
            if (x.score.CompareTo(y.score) == 0) return x.name.CompareTo(y.name);
            return x.score.CompareTo(y.score) * -1;
        });

        if (highScores.highScoreEntryList.Count > 5)
        {
            Debug.Log(highScores.highScoreEntryList.Count);
            highScores.highScoreEntryList.RemoveAt(5);
        }

        string json = JsonUtility.ToJson(highScores);

        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry {
        public string name;
        public int round;
        public int score;
    }
}
