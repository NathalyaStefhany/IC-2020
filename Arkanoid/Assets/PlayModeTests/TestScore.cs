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

            ball = GameObject.FindObjectOfType<Ball>();
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOneYellowBlock()
        {
            foreach (Block block in blocks)
            {
                if (block.points == 10)
                {
                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    break;
                }
            }

            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(10, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyTwoYellowBlocks()
        {
            foreach (Block block in blocks)
            {
                if (block.points == 10)
                {
                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(1);
                }
            }

            Score score = GameObject.FindObjectOfType<Score>();

            Assert.AreEqual(20, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOnePinkBlock()
        {
            foreach (Block block in blocks)
            {
                if (block.points == 30)
                {
                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(1);

                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    break;
                }
            }

            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(30, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyOneBlueBlock()
        {
            foreach (Block block in blocks)
            {
                if (block.points == 50)
                {
                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(1);

                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    yield return new WaitForSeconds(1);

                    ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                    ball.ThrowBall();

                    break;
                }
            }

            Score score = GameObject.FindObjectOfType<Score>();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(50, score.getPlayerPoints());
        }

        [UnityTest]
        public IEnumerator TestScoreWhenDestroyAllBlocks()
        {
            int num;

            Block.destructibleBlockNum = 100;

            foreach (Block block in blocks)
            {
                if (block.tag == "Destructible")
                {
                    if (block.points == 10)
                        num = 1;
                    else if (block.points == 30)
                        num = 2;
                    else
                        num = 3;

                    for(int i = 0; i < num; i++)
                    {
                        ball.transform.position = new Vector2(block.transform.position.x - 0.5f, platform.transform.position.y);
                        ball.ThrowBall();

                        yield return new WaitForSeconds(1);
                    }
                }
            }

            Score score = GameObject.FindObjectOfType<Score>();

            Assert.AreEqual(100, score.getPlayerPoints());
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
