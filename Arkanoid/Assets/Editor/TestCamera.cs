using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
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
            EditorSceneManager.OpenScene("Assets/Scenes/Menu.unity");

            yield return null;

            Assert.IsTrue(GameObject.Find("Main Camera"), "Camera não encontrada!");
        }
    }
}
