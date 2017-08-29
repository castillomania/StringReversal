using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StringTestApp;

namespace StringTestTests
{
    /// <summary>
    /// I only wrote happy-path tests because I didn't want to sink too much time into this exercise. Otherwise, I might have fleshed out a bunch of expected-failure tests as well
    /// </summary>
    [TestClass]
    public class StringTestTest
    {
        [TestMethod]
        public void TestSuccessfulReversing()
        {
            string testString = "Seattle Pacific University";
            string testOutput = "";
            Dictionary<string, long> letterCount = new Dictionary<string, long>();

            StringTest stringTest = new StringTest();
            stringTest.StringParser(testString, out testOutput, out letterCount);
            
            Assert.IsTrue(testOutput == "ytisrevinU cificaP elttaeS");
        }

        [TestMethod]
        public void TestSuccessfulLetterCount()
        {
            string testString = "Seattle Pacific University";
            string testOutput = "";
            Dictionary<string, long> letterCount = new Dictionary<string, long>();

            StringTest stringTest = new StringTest();
            stringTest.StringParser(testString, out testOutput, out letterCount);

            Assert.IsTrue(letterCount.Count == 15); // there are 15 distinct character in the test string

            // validate each letter's count
            Assert.IsTrue(letterCount.ContainsKey("S") && letterCount["S"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("e") && letterCount["e"] == 3);
            Assert.IsTrue(letterCount.ContainsKey("a") && letterCount["a"] == 2);
            Assert.IsTrue(letterCount.ContainsKey("t") && letterCount["t"] == 3);
            Assert.IsTrue(letterCount.ContainsKey("l") && letterCount["l"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("P") && letterCount["P"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("c") && letterCount["c"] == 2);
            Assert.IsTrue(letterCount.ContainsKey("i") && letterCount["i"] == 4);
            Assert.IsTrue(letterCount.ContainsKey("f") && letterCount["f"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("U") && letterCount["U"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("n") && letterCount["n"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("v") && letterCount["v"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("r") && letterCount["r"] == 1);
            Assert.IsTrue(letterCount.ContainsKey("y") && letterCount["y"] == 1);

            // ensures the space didn't get logged
            Assert.IsFalse(letterCount.ContainsKey(" "));
        }
    }
}
