using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestLoadScenes
    {
        [UnitySetUp]
        public IEnumerator setUp()
        {
            SceneManager.LoadScene("LevelTest");

            yield return new WaitForSeconds(1);

            GameObject block = GameObject.FindGameObjectWithTag("Destructible");

            Platform platform = GameObject.FindObjectOfType<Platform>();
            platform.AutoPlay = true;

            Ball ball = GameObject.FindObjectOfType<Ball>();
            
            ball.transform.position = new Vector2(block.transform.position.x - 0.3f, platform.transform.position.y);
            ball.ThrowBall();
        }

        [UnityTest]
        public IEnumerator testLoadSceneLevel2()
        {
            yield return new WaitForSeconds(1);

            int idScene = SceneManager.GetActiveScene().buildIndex;

            Assert.AreEqual(5, idScene);
        }

        [TearDown]
        public void tearDown()
        {
            Block.destructibleBlockNum = 0;

            PlayerPrefs.SetInt("CurrentScore", 0);
        }
    }
}
