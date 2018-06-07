using System.Collections.Generic;

namespace Randomizowane
{
    public struct Edge
    {
        public int from;
        public int to;

        public Edge(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public List<Edge> ArrayFromNumbers(params int[] nodes)
        {
            if (nodes.Length % 2 != 0)
                return null;

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                edges.Add(new Edge(nodes[i], nodes[i + 1]));
            }

            return edges;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", from, to);
        }
    }
}
