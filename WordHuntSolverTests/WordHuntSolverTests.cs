using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WordHuntSolver;
using System;

namespace WordHuntSolverTests
{
    [TestClass]
    public class WordHuntSolverTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            string expected = "C:\\Users\\VishnuM\\source\\repos\\WordHunt\\WordHuntSolver\\CollinsScrabbleWords.txt";
            Solver sl = new Solver(expected);
            Assert.AreEqual(expected, sl.address);
        }

        [TestMethod]
        public void TestLoadDictionary()
        {
            string filepath = "C:\\Users\\VishnuM\\source\\repos\\WordHunt\\WordHuntSolver\\CollinsScrabbleWords.txt";
            Solver sl = new Solver(filepath);
            int expected = 279496;
            Assert.AreEqual(expected, sl.trie.Count());
            Assert.IsTrue(sl.trie.HasPrefix("H"));
        }

        [TestMethod]
        public void TestWordsFound()
        {
            string filepath = "C:\\Users\\VishnuM\\source\\repos\\WordHunt\\WordHuntSolver\\CollinsScrabbleWords.txt";
            Solver sl = new Solver(filepath);

            char[,] matrix = { { 'H', 'E', 'L' }, { 'M', 'N', 'S' }, { 'M', 'I', 'G' } };
            List<Tuple<int, int>> hem = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0)
            };
            List<Tuple<int, int>> hen = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1)
            };
            List<Tuple<int, int>> hens = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 2)
            };
            List<Tuple<int, int>> hemming = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> ming = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> mig = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> ing = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> gin = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1)
            };
            List<Tuple<int, int>> gis = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 2)
            };
            List<Tuple<int, int>> gins = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 2)
            };
            List<Tuple<int, int>> mis = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 2)
            };
            List<Tuple<int, int>> nis = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 2)
            };
            List<Tuple<int, int>> sin = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 1)
            };
            List<Tuple<int, int>> sig = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> leng = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2)
            };
            List<Tuple<int, int>> mel = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2)
            };
            List<Tuple<int, int>> els = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(1, 2)
            };
            var wordList = new List<List<Tuple<int, int>>>{ els, mel, leng, sig, sin, nis, mis, gins, gis, gin, ing, mig, ming, hemming, hens, hen, hem};
            var expected = new HashSet<ProgressiveWord>();
            foreach(var letterList in wordList)
            {
                expected.Add(new ProgressiveWord(letterList));
            }
            var actual = sl.SolveWordHunt(matrix, 4);
            Outputter o = new Outputter(matrix);
            foreach(var p in actual)
            {
                var s = Outputter.PrintMatrix(o.CreateMatrixFromArray(p.letterList));
            }
            Assert.IsTrue(expected.SetEquals(actual));
        }
    }
}
