using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestLives
    {
        [SetUp]
        public void setUp()
        {
            SceneManager.LoadScene("LevelTest");
        }

        [UnityTest]
        public IEnumerator TestWhenLoseLifeContinuesInTheSameScene()
        {
            int idScene = SceneManager.GetActiveScene().buildIndex;

            Lives lives = GameObject.FindObjectOfType<Lives>();

            int numberLives = lives.getPlayerLives();
            int cont = 0;

            while (numberLives == 3 && cont <= 100)
            {
                yield return new WaitForSeconds(0.1f);

                numberLives = lives.getPlayerLives();

                cont++;
            }

            int newIdScene = SceneManager.GetActiveScene().buildIndex;

            Assert.AreEqual(2, numberLives);
            Assert.AreEqual(idScene, newIdScene);
        }

        [UnityTest]
        public IEnumerator TestWhenLoseAllLivesGoToGameOver()
        {
            Lives lives = GameObject.FindObjectOfType<Lives>();

            int numberLives = lives.getPlayerLives();
            int cont = 0;

            while (numberLives != 0 && cont <= 100)
            {
                yield return new WaitForSeconds(0.1f);

                numberLives = lives.getPlayerLives();

                cont++;
            }

            int newIdScene = SceneManager.GetActiveScene().buildIndex;

            Assert.AreEqual(0, numberLives);
            Assert.AreEqual(7, newIdScene);
        }
    }
}
