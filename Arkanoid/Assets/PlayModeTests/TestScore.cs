using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestScore
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            SceneManager.LoadScene("LevelTestScore");

            yield return new WaitForSeconds(1);

            Platform platform = GameObject.FindObjectOfType<Platform>();
            platform.AutoPlay = true;

            Ball ball = GameObject.FindObjectOfType<Ball>();
            ball.ThrowBall();
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOneYellowBlock()
        {
            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(3);

            Assert.AreEqual(10, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyTwoYellowBlocks()
        {
            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(5);

            Assert.AreEqual(20, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOnePinkBlock()
        {
            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(3);

            Assert.AreEqual(30, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOneBlueBlock()
        {
            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(5);

            Assert.AreEqual(50, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyAllBlocks()
        {
            Score score = GameObject.FindObjectOfType<Score>();

            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Destructible");

            while(blocks.Length != 0)
            {
                yield return new WaitForSeconds(0.1f);

                blocks = GameObject.FindGameObjectsWithTag("Destructible");
            }

            Assert.AreEqual(100, score.getPlayerPoints());
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("CurrentScore", 0);
        }
    }
}
