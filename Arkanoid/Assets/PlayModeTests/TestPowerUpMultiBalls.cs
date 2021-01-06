using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using NSubstitute;

namespace Tests
{
    public class TestPowerUpMultiBalls
    {
        private Ball ball;
        private Platform platform;
        private Lives lives;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            SceneManager.LoadScene("LevelTestScore");

            yield return new WaitForSeconds(1);

            platform = GameObject.FindObjectOfType<Platform>();
            platform.AutoPlay = true;

            ball = GameObject.FindObjectOfType<Ball>();
            lives = GameObject.FindObjectOfType<Lives>();
        }

        [Test]
        public void TestVerifyIfHavePowerUpInScene()
        {
            Block powerUp = GameObject.FindGameObjectWithTag("PowerUpMultiBalls").GetComponent<Block>();

            Assert.NotNull(powerUp);
        }

        [UnityTest]
        public IEnumerator TestIfExecutePowerUpIsCalledWhenBlockIsDestroyed()
        {
            MultiBallsPowerUp multiBallsPowerUp = GameObject.FindObjectOfType<MultiBallsPowerUp>();
         
            var _powerUp = Substitute.For<IPowerUp>();
            multiBallsPowerUp.setPowerUp(_powerUp);

            Block powerUp = GameObject.FindGameObjectWithTag("PowerUpMultiBalls").GetComponent<Block>();

            ball.transform.position = new Vector2(powerUp.transform.position.x - 0.5f, platform.transform.position.y);
            ball.ThrowBall();

            yield return new WaitForSeconds(0.5f);

            _powerUp.Received(1).ExecutePowerUp(ball.gameObject);
        }

        [UnityTest]
        public IEnumerator TestVerifyIfHas3Balls()
        {
            MultiBallsPowerUp multiBallsPowerUp = GameObject.FindObjectOfType<MultiBallsPowerUp>();

            Block powerUp = GameObject.FindGameObjectWithTag("PowerUpMultiBalls").GetComponent<Block>();

            ball.transform.position = new Vector2(powerUp.transform.position.x - 0.5f, platform.transform.position.y);
            ball.ThrowBall();

            yield return new WaitForSeconds(0.5f);

            Ball[] balls = GameObject.FindObjectsOfType<Ball>();

            Assert.AreEqual(3, balls.Length);
        }

        [UnityTest]
        public IEnumerator TestWhenLoseTwoBallsDontLoseLife()
        {
            MultiBallsPowerUp multiBallsPowerUp = GameObject.FindObjectOfType<MultiBallsPowerUp>();

            Block powerUp = GameObject.FindGameObjectWithTag("PowerUpMultiBalls").GetComponent<Block>();

            ball.transform.position = new Vector2(powerUp.transform.position.x - 0.5f, platform.transform.position.y);
            ball.ThrowBall();

            yield return new WaitForSeconds(0.5f);

            Ball[] balls = GameObject.FindObjectsOfType<Ball>();

            while(balls.Length != 1)
            {
                balls = GameObject.FindObjectsOfType<Ball>();

                yield return new WaitForSeconds(0.1f);
            }

            Assert.AreEqual(1, balls.Length);
            Assert.AreEqual(3, lives.getPlayerLives());
        }

        [UnityTest]
        public IEnumerator TestWhenLoseAllBallsLoseLife()
        {
            platform.AutoPlay = false;

            MultiBallsPowerUp multiBallsPowerUp = GameObject.FindObjectOfType<MultiBallsPowerUp>();

            Block powerUp = GameObject.FindGameObjectWithTag("PowerUpMultiBalls").GetComponent<Block>();

            ball.transform.position = new Vector2(powerUp.transform.position.x - 0.5f, platform.transform.position.y);
            ball.ThrowBall();

            yield return new WaitForSeconds(0.5f);

            Ball[] balls = GameObject.FindObjectsOfType<Ball>();

            while (balls.Length != 0 && balls[0].getGameStarted() == true)
            {
                balls = GameObject.FindObjectsOfType<Ball>();

                yield return new WaitForSeconds(0.1f);
            }

            Assert.AreEqual(1, balls.Length);
            Assert.AreEqual(2, lives.getPlayerLives());
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
