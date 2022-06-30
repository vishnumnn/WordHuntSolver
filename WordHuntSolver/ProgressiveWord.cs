using System;
using System.Collections.Generic;
using System.Text;

namespace WordHuntSolver
{
    public class ProgressiveWord
    {
        StringBuilder sb;
        Tuple<int, int> latest;
        HashSet<Tuple<int, int>> letterSet;
        
        public ProgressiveWord(char c, int i, int j)
        {
            sb = new StringBuilder(c);
            letterSet = new HashSet<Tuple<int, int>>();
            latest = new Tuple<int, int>(i, j);
            letterSet.Add(latest);
        }

        public Boolean IsValid(Tuple<int, int> letter)
        {
            if (letterSet.Contains(letter))
                return false;
            return true;
        }

        public ProgressiveWord CloneWithLetter(char c, int i, int j)
        {
            ProgressiveWord clone = new ProgressiveWord(c, i, j);
            foreach(var tup in this.letterSet)
            {
                clone.letterSet.Add(tup);
            }
            return clone;
        }

        public Tuple<int, int> Peek()
        {
            return latest;
        }

        public int Len()
        {
            return letterSet.Count;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
