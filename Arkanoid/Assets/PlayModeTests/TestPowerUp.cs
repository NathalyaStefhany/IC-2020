using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestPowerUp
    {
        private Ball ball;
        private Platform platform;
        private Block[] blocks;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            SceneManager.LoadScene("LevelTestScore");

            yield return new WaitForSeconds(1);

            blocks = GameObject.FindObjectsOfType<Block>();

            platform = GameObject.FindObjectOfType<Platform>();
            platform.AutoPlay = true;

            Block powerUp = GameObject.FindGameObjectWithTag("PowerUp").GetComponent<Block>();

            ball = GameObject.FindObjectOfType<Ball>();

            ball.transform.position = new Vector2(powerUp.transform.position.x - 0.5f, platform.transform.position.y);
            ball.ThrowBall();

            yield return new WaitForSeconds(0.5f);
        }

        [UnityTest]
        public IEnumerator TestStrongDamage()
        {
            Block blueBlock = blocks[0];

            foreach (Block block in blocks)
            {
                if (block.points == 50)
                {
                    blueBlock = block;

                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(0.5f);

                    break;
                }
            }

            Assert.IsTrue(blueBlock == null);
        }

        [UnityTest]
        public IEnumerator TestWhenDieLosePowerUp()
        {
            ball.transform.position = new Vector2(0, -6);

            yield return new WaitForSeconds(0.1f);

            Block blueBlock = blocks[0];

            foreach (Block block in blocks)
            {
                if (block.points == 50)
                {
                    blueBlock = block;

                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(0.5f);

                    break;
                }
            }

            Assert.IsTrue(blueBlock.isActiveAndEnabled);
        }

        [TearDown]
        public void TearDown()
        {
            Block.destructibleBlockNum = 0;

            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("CurrentScore", 0);
        }
    }
}
