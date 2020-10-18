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

        string jsonString = PlayerPrefs.GetString("HighScoreTable");

        if (string.IsNullOrEmpty(jsonString) == false)
        {
            HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

            highScoreEntryTransformList = new List<Transform>();

            foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }
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
}
