using System;
using System.Collections.Generic;
using System.Text;

namespace WordHuntKiller
{
    public class ProgressiveWord
    {
        List<Tuple<int, int>> pWord;
        HashSet<Tuple<int, int>> letterSet;
        
        public ProgressiveWord(char c, int i, int j)
        {
            pWord = new List<Tuple<int, int>>();
            letterSet = new HashSet<Tuple<int, int>>();
            var x = new Tuple<int, int>(i, j);
            pWord.Add(x);
            letterSet.Add(x);
        }

        public void AddLetter(int i, int j)
        {
            var letterTuple = new Tuple<int, int>(i, j);
            pWord.Add(letterTuple);
            letterSet.Add(letterTuple);
        }

        public Tuple<int, int> Peek()
        {
            return pWord[pWord.Count];
        }

        public Boolean IsValid(Tuple<int, int> letter)
        {
            if (letterSet.Contains(letter))
                return false;
            return true;
        }
    }
}
