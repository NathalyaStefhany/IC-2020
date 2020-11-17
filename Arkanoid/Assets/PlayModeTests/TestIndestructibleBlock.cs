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
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            SceneManager.LoadScene("LevelTestScore");

            yield return new WaitForSeconds(1);

            GameObject block = GameObject.FindGameObjectWithTag("Indestructible");

            Platform platform = GameObject.FindObjectOfType<Platform>();
            platform.AutoPlay = true;

            Ball ball = GameObject.FindObjectOfType<Ball>();

            ball.transform.position = new Vector2(block.transform.position.x - 0.3f, platform.transform.position.y);
            ball.ThrowBall();
        }

        [UnityTest]
        public IEnumerator TestBlockIsNotDestroyed()
        {
            yield return new WaitForSeconds(1);

            GameObject indestructibleBlock = GameObject.FindGameObjectWithTag("Indestructible");

            Assert.IsTrue(Block.hit, "Didn't hit the block");
            Assert.IsNotNull(indestructibleBlock, "There isn't indestructible block in the scene");
        }
    }
}
