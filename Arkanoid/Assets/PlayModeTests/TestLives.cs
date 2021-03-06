﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestLives
    {
        private Ball ball;

        [UnitySetUp]
        public IEnumerator setUp()
        {
            SceneManager.LoadScene("LevelTest");

            yield return new WaitForSeconds(1);

            GameObject platform = GameObject.FindGameObjectWithTag("Platform");

            ball = GameObject.FindObjectOfType<Ball>();

            ball.ThrowBall();
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

            int cont = 0;

            while (cont < 2)
            {
                yield return new WaitForSeconds(2.5f);

                ball = GameObject.FindObjectOfType<Ball>();
                ball.ThrowBall();

                cont++;
            }

            yield return new WaitForSeconds(2.5f);

            int numberLives = lives.getPlayerLives();
            int newIdScene = SceneManager.GetActiveScene().buildIndex;

            Assert.AreEqual(0, numberLives);
            Assert.AreEqual(7, newIdScene);
        }

        [TearDown]
        public void tearDown()
        {
            Block.destructibleBlockNum = 0;

            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("CurrentScore", 0);
        }
    }
}
