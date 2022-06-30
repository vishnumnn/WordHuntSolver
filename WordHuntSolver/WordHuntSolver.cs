using System;
using System.Collections.Generic;
using System.IO;
using rm.Trie;

namespace WordHuntSolver
{
    public class WordHuntSolver
    {
        ITrie trie;
        String address;
        char[,] matrix = new char[4, 4];

        public WordHuntSolver(char[,] matrix, string wordsPath = "./CollinsScrabbleWords.txt")
        {
            this.matrix = matrix;
            address = wordsPath;
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

        private char[,] CreateMatrixFromArray(Tuple<int, int>[] ar)
        {
            char[,] res = new char[4, 4];
            foreach (Tuple<int, int> el in ar)
            {
                (var i, var j) = el;
                res[i, j] = matrix[i, j];
            }
            return res;
        }


        private List<Tuple<int, int>> GetValidAdjacents(ProgressiveWord curr)
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

        public HashSet<string> SolveWordHunt()
        {
            Queue<ProgressiveWord> q = new Queue<ProgressiveWord>();
            HashSet<string> found = new HashSet<string>();
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
                if(curr.Len() >= 3 && trie.HasWord(currStr))
                {
                    found.Add(currStr);
                }
                else if (trie.HasPrefix(currStr))
                {
                    var adjs = GetValidAdjacents(curr);
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