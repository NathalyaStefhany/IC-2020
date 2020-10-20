using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestAddScore
    {
        private AddScore addScore;
        private HighScoreEntry highScoreEntry1, highScoreEntry2, highScoreEntry3;
        private HighScores highScores;

        [SetUp]
        public void init()
        {
            addScore = GameObject.FindObjectOfType<AddScore>();

            highScoreEntry1 = new HighScoreEntry { name = "NATH", round = 1, score = 1500 };
            highScoreEntry2 = new HighScoreEntry { name = "STEF", round = 1, score = 3000 };
            highScoreEntry3 = new HighScoreEntry { name = "PER", round = 1, score = 1000 };

            highScores = new HighScores();

            highScores.highScoreEntryList = new List<HighScoreEntry>();
        }

        [Test]
        public void testSortScore()
        {
            highScores.highScoreEntryList.Add(highScoreEntry1);
            highScores.highScoreEntryList.Add(highScoreEntry2);
            highScores.highScoreEntryList.Add(highScoreEntry3);

            highScores = addScore.sortScore(highScores);

            Assert.AreSame(highScoreEntry2, highScores.highScoreEntryList[0]);
            Assert.AreSame(highScoreEntry1, highScores.highScoreEntryList[1]);
            Assert.AreSame(highScoreEntry3, highScores.highScoreEntryList[2]);
        }
    }
}