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
        [SetUp]
        public void setUp()
        {
            SceneManager.LoadScene("LevelTest");
        }

        [UnityTest]
        public IEnumerator testLoadSceneLevel2()
        {
            yield return new WaitForSeconds(3);

            int idScene = SceneManager.GetActiveScene().buildIndex;

            Assert.AreEqual(5, idScene);
        }

        [TearDown]
        public void tearDown()
        {
            Block.destructibleBlockNum = 0;
        }
    }
}
