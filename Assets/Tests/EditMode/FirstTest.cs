using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace EditModeTests
{
    public class FirstTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FirstTestSimplePasses()
        {
            // Most of the times this is not appropriate checking for test (this is standard
            // .NET comparison for objects). Use 'Assert.AreEquals()' instead.
            // Assert.Equals()
            
            // Arrange.
            List<string> strings = new List<string>();
            
            // Act.
            strings.Add("Test string 1");
            strings.Add("Test string 2");
            strings.RemoveAt(0);
            
            // Assert.
            Assert.AreEqual(2, strings.Count);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FirstTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
