using System;
using System.Collections.Generic;

namespace Randomizowane
{
    public class Node
    {
        public int index;

        public Node(int idx)
        {
            index = idx;
        }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}
