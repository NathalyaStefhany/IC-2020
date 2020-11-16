using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestIndestructibleBlock
    {
        [SetUp]
        public void SetUp()
        {
            SceneManager.LoadScene("LevelTestScore");
        }

        [UnityTest]
        public IEnumerator TestBlockIsNotDestroyed()
        {
            yield return new WaitForSeconds(3);

            GameObject indestructibleBlock = GameObject.FindGameObjectWithTag("Indestructible");

            Assert.IsTrue(Block.hit, "Didn't hit the block");
            Assert.IsNotNull(indestructibleBlock, "There isn't indestructible block in the scene");
        }
    }
}
