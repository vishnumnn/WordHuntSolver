using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WordHuntSolver;
using System;

namespace WordHuntSolverTests
{
    [TestClass]
    public class ProgressiveWordTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            ProgressiveWord w = new ProgressiveWord('h', 0, 0);
            var latest = new Tuple<int, int>(0, 0);
            var expectedLetterList = new List<Tuple<int, int>>()
            {
                latest
             };
            var expectedHashSet = new HashSet<Tuple<int, int>>
            {
                latest
            };
            CollectionAssert.AreEqual(expectedLetterList, w.letterList);
            Assert.IsTrue(expectedHashSet.SetEquals(w.letterSet));
        }

        [TestMethod]
        public void TestToString()
        {
            ProgressiveWord w = new ProgressiveWord('h', 0, 0);
            var expected = "h";
            Assert.AreEqual(expected, w.ToString());
        }

        [TestMethod]
        public void TestClone()
        {
            ProgressiveWord w = new ProgressiveWord('h', 0, 0);
            var n = w.CloneWithLetter('e', 0, 1);
            var newest = new Tuple<int, int>(0, 1);
            var latest = new Tuple<int, int>(0, 0);
            var expectedLetterList = new List<Tuple<int, int>>()
            {
                latest, newest
             };
            var expectedHashSet = new HashSet<Tuple<int, int>>
            {
                latest, newest
            };
            CollectionAssert.AreEqual(expectedLetterList, n.letterList);
            Assert.IsTrue(expectedHashSet.SetEquals(n.letterSet));
            Assert.AreEqual("he", n.ToString());
        }
    }
}
