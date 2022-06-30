using System;
using System.Collections.Generic;
using System.Text;

namespace WordHuntSolver
{
    public class Node
    {
        Node parent;
        Dictionary<char, Node> children;
        char value;

        public Node(Node parent, char c)
        {
            value = c;
            this.parent = parent;
        }

        public void AddChild(Node child)
        {
            children.Add(child.value, child);
        }

        public char GetValue()
        {
            return value;
        }

        public Node GetChild(char c)
        {
            if (children.ContainsKey(c))
            {
                return children[c];
            }
            return null;
        }
    }
}
