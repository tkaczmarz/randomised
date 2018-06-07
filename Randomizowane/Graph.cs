using System.Collections.Generic;
using System.Linq;

namespace Randomizowane
{
    /*
     * Najlepiej tworzyć graf od kolekcji krawędzi.
     * Z krawędzi tworzyć odpowiednio połączone punkty.
     * Do algorytmu losować krawędzie (to da równe prawdopodobieństwo na wylosowanie każdego).
     */
    public class Graph
    {
        public List<Node> V = new List<Node>();
        public HashSet<Edge> E = new HashSet<Edge>();

        public Graph(int nodesCount, params Edge[] edges)
        {
            //V = new List<Node>(nodesCount);
            //E = edges.ToList();

            //foreach (Edge e in E)
            //{
            //    V[e.from].neighbors.Add(V[e.to]);
            //    V[e.to].neighbors.Add(V[e.from]);
            //}
        }

        public Graph(int[][] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                V.Add(new Node(i));
                for (int j = 0; j < nodes[i].Length; j++)
                {
                    V[i].neighbors.Add(nodes[i][j]);
                    E.Add(new Edge(i, nodes[i][j]));
                }
            }
        }

        public override string ToString()
        {
            string str = "Nodes:\n";
            foreach (Node n in V)
            {
                str += n.idx + ": { ";
                foreach (int i in n.neighbors)
                {
                    str += i + " ";
                }
                str += "}\n";
            }
            str += "Edges:\n";
            foreach (Edge e in E)
            {
                str += e.from + " - " + e.to + "\n";
            }

            return str;
        }
    }
}
