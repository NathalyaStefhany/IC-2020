using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestBlocks
    {
        private GameObject[] blocks;

        [SetUp]
        public void setUp()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");

            blocks = GameObject.FindGameObjectsWithTag("Destructible");
        }

        [Test]
        public void testNumberBlocksSceneLevel1()
        {
            Assert.AreEqual(57, blocks.Length);
        }

        [Test]
        public void testDestroyAllBlocks()
        {
            foreach(GameObject block in blocks)
                GameObject.DestroyImmediate(block);

            Assert.AreEqual(0, Block.destructibleBlockNum);
        }
    }
}
