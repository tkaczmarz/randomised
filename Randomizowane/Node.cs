using System.Collections.Generic;

namespace Randomizowane
{
    public class Node
    {
        public int idx = -1;
        public List<int> neighbors = new List<int>();

        public Node(int idx)
        {
            this.idx = idx;
        }
    }
}
