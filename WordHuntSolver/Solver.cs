using System;
using System.Collections.Generic;
using System.IO;
using rm.Trie;

namespace WordHuntSolver
{
    public class Solver
    {
        public ITrie trie;
        public String address;
        
        public Solver(string wordsPath = "./CollinsScrabbleWords.txt")
        {
            address = wordsPath;
            trie = new Trie();
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            using (StreamReader SR = new StreamReader(address))
            {
                string line = "";
                while ((line = SR.ReadLine()) != null)
                {
                    trie.AddWord(line);
                }
            }

        }


        private List<Tuple<int, int>> GetValidAdjacents(char[,] matrix , ProgressiveWord curr)
        {
            List<Tuple<int, int>> adjs = new List<Tuple<int, int>>();
            (int i, int j) = curr.Peek();
            Tuple<int, int> tup;
            if(i + 1 < matrix.GetLength(0))
            {
                tup = new Tuple<int, int>(i + 1, j);
                if (curr.IsValid(tup))
                    adjs.Add(tup);
                tup = new Tuple<int, int>(i + 1, j + 1);
                if(j + 1 < matrix.GetLength(1) && curr.IsValid(tup))
                    adjs.Add(tup);
                tup = new Tuple<int, int>(i + 1, j - 1);
                if (j - 1 >= 0 && curr.IsValid(tup))
                    adjs.Add(tup);
            }
            if(i - 1 >= 0)
            {
                tup = new Tuple<int, int>(i - 1, j);
                if (curr.IsValid(tup))
                    adjs.Add(tup);
                tup = new Tuple<int, int>(i - 1, j + 1);
                if (j + 1 < matrix.GetLength(1) && curr.IsValid(tup))
                    adjs.Add(tup);
                tup = new Tuple<int, int>(i - 1, j - 1);
                if (j - 1 >= 0 && curr.IsValid(tup))
                    adjs.Add(tup);
            }
            tup = new Tuple<int, int>(i, j - 1);
            if (j - 1 >= 0 && curr.IsValid(tup))
                adjs.Add(tup);
            tup = new Tuple<int, int>(i, j + 1);
            if (j + 1 < matrix.GetLength(1) && curr.IsValid(tup))
                adjs.Add(tup);
            return adjs;
        }

        public HashSet<ProgressiveWord> SolveWordHunt(char[,] matrix, int minLetterCount)
        {
            Queue<ProgressiveWord> q = new Queue<ProgressiveWord>();
            var found = new HashSet<ProgressiveWord>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    q.Enqueue(new ProgressiveWord(matrix[i, j], i, j));
                }
            }

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                string currStr = curr.ToString();
                if(currStr.Length >= minLetterCount && trie.HasWord(currStr))
                {
                    found.Add(curr);
                }
                if (trie.HasPrefix(currStr))
                {
                    var adjs = GetValidAdjacents(matrix, curr);
                    foreach(var adj in adjs)
                    {
                        q.Enqueue(curr.CloneWithLetter(matrix[adj.Item1, adj.Item2], adj.Item1, adj.Item2));
                    }
                }
            }
            return found;
        }
    }
}