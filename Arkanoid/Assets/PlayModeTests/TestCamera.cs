using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestCamera
    {
        [UnityTest]
        public IEnumerator TestCameraExists()
        {
            SceneManager.LoadScene("Menu");

            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(GameObject.Find("Main Camera"), "Camera não encontrada!");
        }
    }
}
