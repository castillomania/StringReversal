using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StringTestApp;

namespace StringTestTests
{
    /// <summary>
    /// I'm sure we could come up with more tests, but this seems like a good first-pass
    /// </summary>
    [TestClass]
    public class StringTestTest
    {
        private string _testString;
        private string _testOutput;
        private Dictionary<string, long> _letterCount;

        [TestInitialize]
        public void StringTestTestSetup()
        {
            _testString = "Seattle Pacific University";
            _testOutput = "";
            _letterCount = new Dictionary<string, long>();

            StringTest stringTest = new StringTest();
            stringTest.StringParser(_testString, out _testOutput, out _letterCount);
        }

        [TestMethod]
        public void TestSuccessfulReversing()
        {
            // makes sure that the output is properly reversed
            Assert.IsTrue(_testOutput == "ytisrevinU cificaP elttaeS");
        }

        [TestMethod]
        public void TestSuccessfulLetterCount()
        {
            // there are 15 distinct characters in the test string
            Assert.IsTrue(_letterCount.Count == 15); 
        }

        [TestMethod]
        public void TestSuccessfulLoggingOfEachLetter()
        {
            // validate each letter's count
            Assert.IsTrue(_letterCount.ContainsKey("S") && _letterCount["S"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("e") && _letterCount["e"] == 3);
            Assert.IsTrue(_letterCount.ContainsKey("a") && _letterCount["a"] == 2);
            Assert.IsTrue(_letterCount.ContainsKey("t") && _letterCount["t"] == 3);
            Assert.IsTrue(_letterCount.ContainsKey("l") && _letterCount["l"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("P") && _letterCount["P"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("c") && _letterCount["c"] == 2);
            Assert.IsTrue(_letterCount.ContainsKey("i") && _letterCount["i"] == 4);
            Assert.IsTrue(_letterCount.ContainsKey("f") && _letterCount["f"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("U") && _letterCount["U"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("n") && _letterCount["n"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("v") && _letterCount["v"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("r") && _letterCount["r"] == 1);
            Assert.IsTrue(_letterCount.ContainsKey("y") && _letterCount["y"] == 1);
        }

        [TestMethod]
        public void TestThatSpacesAreExcluded()
        {
            // ensures the space didn't get logged
            Assert.IsFalse(_letterCount.ContainsKey(" "));
        }
    }
}
