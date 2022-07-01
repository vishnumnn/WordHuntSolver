using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordHuntSolver
{
    public class ProgressiveWord
    {
        public StringBuilder sb;
        public HashSet<Tuple<int, int>> letterSet;
        public List<Tuple<int, int>> letterList;
        
        public ProgressiveWord(char c, int i, int j)
        {
            sb = new StringBuilder();
            sb.Append(c);
            letterSet = new HashSet<Tuple<int, int>>();
            letterList = new List<Tuple<int, int>>();
            var latest = new Tuple<int, int>(i, j);
            letterSet.Add(latest);
            letterList.Add(latest);
        }

        public ProgressiveWord(List<Tuple<int,int>> letterList)
        {
            this.letterList = letterList;
        }

        public Boolean IsValid(Tuple<int, int> letter)
        {
            if (letterSet.Contains(letter))
                return false;
            return true;
        }

        public ProgressiveWord CloneWithLetter(char c, int i, int j)
        {
            var firstTup = letterList[0];
            ProgressiveWord clone = new ProgressiveWord(sb[0], firstTup.Item1, firstTup.Item2);
            for(int k = 1; k < letterList.Count; k++)
            {
                clone.letterSet.Add(letterList[k]);
                clone.letterList.Add(letterList[k]);
                clone.sb.Append(sb[k]);
            }
            var toAdd = new Tuple<int, int>(i, j);
            clone.letterSet.Add(toAdd);
            clone.letterList.Add(toAdd);
            clone.sb.Append(c);
            return clone;
        }

        public Tuple<int, int> Peek()
        {
            return letterList[letterList.Count - 1];
        }

        public int Len()
        {
            return letterSet.Count;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var word = (ProgressiveWord)obj;
            return sb.Equals(word.sb);
        }

        public override int GetHashCode()
        {
            return sb.ToString().GetHashCode();
        }
    }
}
