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
        private HighScoreEntry highScoreEntry1, highScoreEntry2, highScoreEntry3, highScoreEntry4;
        private HighScores highScores;

        [SetUp]
        public void init()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");

            addScore = new AddScore();

            highScoreEntry1 = new HighScoreEntry { name = "NATH", round = 1, score = 1500 };
            highScoreEntry2 = new HighScoreEntry { name = "JOAO", round = 2, score = 3000 };
            highScoreEntry3 = new HighScoreEntry { name = "ANDR", round = 1, score = 1000 };
            highScoreEntry4 = new HighScoreEntry { name = "ANDR", round = 1, score = 1500 };

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

        [Test]
        public void testSortByNameWhenScoreEqual()
        {
            highScores.highScoreEntryList.Add(highScoreEntry1);
            highScores.highScoreEntryList.Add(highScoreEntry2);
            highScores.highScoreEntryList.Add(highScoreEntry3);
            highScores.highScoreEntryList.Add(highScoreEntry4);

            highScores = addScore.sortScore(highScores);

            Assert.AreSame(highScoreEntry2, highScores.highScoreEntryList[0]);
            Assert.AreSame(highScoreEntry4, highScores.highScoreEntryList[1]);
            Assert.AreSame(highScoreEntry1, highScores.highScoreEntryList[2]);
            Assert.AreSame(highScoreEntry3, highScores.highScoreEntryList[3]);
        }
    }
}