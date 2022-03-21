using System;
using System.Collections.Generic;
using System.IO;

namespace WordHuntKiller
{
    public class WordHuntSolver
    {
        static HashSet<string> words = new HashSet<string>();
        static String address = "./CollinsScrabbleWords.txt";
        char[,] matrix = new char[4, 4];

        public WordHuntSolver(char[,] matrix)
        {
            this.matrix = matrix;
        }

        private static void LoadDictionary()
        {
            using (StreamReader SR = new StreamReader(address))
            {
                string line = "";
                while ((line = SR.ReadLine()) != null)
                {
                    words.Add(line);
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

        public static void SolveWordHunt()
        {
            Queue<ProgressiveWord> q = new Queue<ProgressiveWord>();
            HashSet<char> visited = new HashSet<char>();
            while(q.Count > 0)
            {

            }
        }
    }
}